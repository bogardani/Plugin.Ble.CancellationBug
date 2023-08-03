namespace CancellationBug;

public class BluetoothPermission : Permissions.BasePlatformPermission
{
    public BluetoothPermission() { }

    public override (string androidPermission, bool isRuntime)[] RequiredPermissions =>
                new (string, bool)[]
                {
                    (global::Android.Manifest.Permission.BluetoothScan, true),
                    (global::Android.Manifest.Permission.BluetoothConnect, true),
                };
}