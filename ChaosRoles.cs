using ChaosRoles.Roles;
using Lotus.Addons;
using Lotus.GameModes.Standard;
using ChaosRoles.Version;
using UnityEngine.ProBuilder;

namespace ChaosRoles;

public class ChaosRoles: LotusAddon
{
    public override void Initialize()
    {
        // Register Crew Roles
        StandardRoles.AddRole(new British());
        StandardRoles.AddRole(new Kamikaze()); /* 
        StandardRoles.AddRole(new Paramedic());
        StandardRoles.AddRole(new Reviver());
        StandardRoles.AddRole(new Wizard());
        // Register Neutral Roles
        StandardRoles.AddRole(new Dracula());
        StandardRoles.AddRole(new Hustler());
        StandardRoles.AddRole(new Lawyer());
        StandardRoles.AddRole(new Magician()); */
        Log.Warning("Welcome to ChaosRoles!");
    }

    public override string Name { get;} = "ChaosRoles";

    public override VentLib.Version.Version Version { get;} = new ChaosRolesAddonVersion();
}


