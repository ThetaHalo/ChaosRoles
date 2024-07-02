using SampleRoleAddon.Roles;
using Lotus.Addons;
using Lotus.GameModes.Standard;
using SampleRoleAddon.Version;

namespace SampleRoleAddon;

public class SampleRoleAddon: LotusAddon
{
    public override void Initialize()
    {
        StandardRoles.AddRole(new CrewCrew());
    }

    public override string Name { get;} = "Sample Role Addon";

    public override VentLib.Version.Version Version { get;} = new SampleLotusAddonVersion();
}


