using SampleRoleAddon.Roles;
using TOHTOR.Addons;

namespace SampleRoleAddon;

public class SampleRoleAddon: TOHAddon
{
    public override void Initialize()
    {
        RegisterRole(new CrewCrew());
    }

    public override string AddonName() => "Sample Role Addon";

    public override string AddonVersion() => "1.2.3";
}


