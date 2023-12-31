namespace WarehouseScanner.Resources;

internal static class Assets
{
    // hi person looking through this repo
    
    private static AssetBundle _bundle;
    public static GameObject Scanner { get; private set; }

    public static void Load()
    {
        _bundle = HelperMethods.LoadEmbeddedAssetBundle(Main.CurrAsm, HelperMethods.IsAndroid() ? "WarehouseScanner.Resources.Android.bundle" : "WarehouseScanner.Resources.Windows.bundle");
        // i didn't feel like naming the prefab something normal
        // god i love rebuilding the bundle every time i make a little mistake
        Scanner = _bundle.LoadPersistentAsset<GameObject>("Assets/Dickweed.prefab");
    }
}