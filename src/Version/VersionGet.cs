using Hazel;
using VentLib.Version;

namespace ChaosRoles.Version;


/// <summary>
/// Version Representing this Addon
/// </summary>
public class ChaosRolesAddonVersion: VentLib.Version.Version
{
    public override VentLib.Version.Version Read(MessageReader reader)
    {
        return new ChaosRolesAddonVersion();
    }

    protected override void WriteInfo(MessageWriter writer)
    {
    }

    public override string ToSimpleName()
    {
        return "ChaosRoles v0.1.0";
    }

    public override string ToString() => "ChaosRolesAddonVersion";
}