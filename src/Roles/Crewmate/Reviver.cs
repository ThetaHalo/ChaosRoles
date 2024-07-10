// Not Implemented
using UnityEngine;
using System.Collections.Generic;
using System;
using System.Reflection;
using Lotus;
using Lotus.Logging;
using Lotus.Chat;
using Lotus.Extensions;
using Lotus.GUI;
using Lotus.GUI.Name;
using Lotus.GUI.Name.Impl;
using Lotus.Roles;
using Lotus.Roles.Internals.Attributes;
using Lotus.Roles.RoleGroups.Vanilla;
using Lotus.Roles.Interactions.Interfaces;
using Lotus.Roles.Interactions;
using Lotus.Roles.Internals;
using Lotus.Utilities;
using Lotus.Victory.Conditions;
using Lotus.Roles.Internals.Enums;
using Lotus.API.Odyssey;
using Lotus.Managers.History.Events;
using VentLib.Localization.Attributes;
using VentLib.Options.UI;
using VentLib.Utilities.Extensions;
namespace ChaosRoles.Roles;
public class Reviver: Crewmate
{
    [Localized("WarningMessage")]
    private static string _warningMessage = "WarningMessage";
    
    // Settings
    private bool notImplemented;
    private int notImplemented2;
    // end

protected override GameOptionBuilder RegisterOptions(GameOptionBuilder optionStream) =>
        base.RegisterOptions(optionStream)
            .SubOption(sub => sub.Name("Name Cooldown after Lights")
                .AddIntRange(1, 15, 1, 7)
                .BindInt(i => notImplemented2 = i)
                .ShowSubOptionPredicate(o => (int)o > 1)
                .Build())
            .SubOption(sub => sub.Name("Time till Suicide")
                .AddBoolean()
                .BindBool(b => notImplemented = b)
                .Build())
            .SubOption(sub => sub.Name("Send Warning Message")
                .AddBoolean()
                .BindBool(b => notImplemented = b)
                .Build());

[Localized(nameof(Reviver))]
    private static class Translations
    {
        
    }
}