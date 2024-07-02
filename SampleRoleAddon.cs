using SampleRoleAddon.Roles;
using Lotus.Addons;
using VentLib.Version;
using Lotus.GameModes.Standard;

namespace SampleRoleAddon;

public class SampleRoleAddon: LotusAddon
{
    public override void Initialize()
    {
        StandardRoles.AddRole(new CrewCrew());
    }

    public override string Name { get;} = "Sample Role Addon";

    public override Version Version { get;} = new SampleLotusAddonVersion();
}


