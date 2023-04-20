using System.Collections.Generic;
using TOHTOR.API;
using TOHTOR.Extensions;
using TOHTOR.GUI;
using TOHTOR.GUI.Name;
using TOHTOR.Roles;
using TOHTOR.Roles.Internals.Attributes;
using TOHTOR.Roles.RoleGroups.Vanilla;
using TOHTOR.Utilities;
using TOHTOR.Victory.Conditions;
using UnityEngine;
using VentLib.Localization.Attributes;
using VentLib.Options.Game;

namespace SampleRoleAddon.Roles;

// The "Crew Crew" is a Crewmate role that does something.
// If "Crew Crew" successfully reports enough players (determined by host) they win the game! It's that simple
[Localized($"Roles.{nameof(CrewCrew)}")] // used for localization, not needed on files unless you utilize localization
public class CrewCrew: Crewmate // There are a couple built-in role types you can extend from, crew mate is one of them.
{
    [Localized("WarningMessage")]
    private static string _warningMessage = "The {0) is close to winning! Vote them out this meeting or lose!";
    
    // Settings
    private int reportedPlayersBeforeWin;
    private bool makesBodiesUnreportable;
    private bool sendWarningMessageOnWin;
    
    // Instance-based variables below

    [NewOnSetup] 
    private HashSet<byte> grabbedPlayers;

    [UIComponent(UI.Cooldown)] // For rendering the cooldown
    private Cooldown reportBodyCooldown;

    private string ReportedPlayerCounter() => RoleUtils.Counter(grabbedPlayers.Count, reportedPlayersBeforeWin);

    [RoleAction(RoleActionType.SelfReportBody)]
    public void ReportAbility(GameData.PlayerInfo reportedBody)
    {
        if (reportBodyCooldown.NotReady()) return;
        reportBodyCooldown.Start();
        
        grabbedPlayers.Add(reportedBody.PlayerId);
        if (makesBodiesUnreportable) Game.GameStates.UnreportableBodies.Add(reportedBody.PlayerId);
    }

    [RoleAction(RoleActionType.RoundStart)]
    public void ActiveGameWin()
    {
        if (CheckWinCondition()) ManualWin.Activate(MyPlayer, WinReason.SoloWinner, 999);
    }

    [RoleAction(RoleActionType.RoundEnd)]
    public void NotifyDuringMeeting()
    {
        if (!CheckWinCondition() || !sendWarningMessageOnWin) return;
        Utils.SendMessage(string.Format(_warningMessage, MyPlayer.UnalteredName()), title: "CrewCrew Win");
    }

    private bool CheckWinCondition() => grabbedPlayers.Count >= reportedPlayersBeforeWin;

    // This registers the options in the option menu
    protected override GameOptionBuilder RegisterOptions(GameOptionBuilder optionStream) =>
        base.RegisterOptions(optionStream)
            .SubOption(sub => sub.Name("Reported Bodies Amount")
                .AddIntRange(1, 15, 1, 7)
                .BindInt(i => reportedPlayersBeforeWin = i)
                .ShowSubOptionPredicate(o => (int)o > 1)
                .Build())
            .SubOption(sub => sub.Name("Report Body Cooldown")
                .AddFloatRange(0, 120, 2.5f, suffix: "s")
                .BindFloat(reportBodyCooldown.SetDuration)
                .Build())
            .SubOption(sub => sub.Name("Make Body Unreportable")
                .AddOnOffValues()
                .BindBool(b => makesBodiesUnreportable = b)
                .Build())
            .SubOption(sub => sub.Name("Send Warning Message")
                .AddOnOffValues()
                .BindBool(b => sendWarningMessageOnWin = b)
                .Build());

    protected override RoleModifier Modify(RoleModifier roleModifier) => 
        base.Modify(roleModifier).RoleColor(Color.magenta);
}