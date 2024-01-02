namespace WarehouseScanner;

public class Main : MelonMod
{
    internal const string Name = "WarehouseScanner";
    internal const string Description = "Scan crates, get barcodes.";
    internal const string Author = "SoulWithMae";
    internal const string Company = "Weather Electric";
    internal const string Version = "1.2.0";
    internal const string DownloadLink = "https://bonelab.thunderstore.io/package/SoulWithMae/WarehouseScanner/";
    
    internal static Assembly CurrAsm => Assembly.GetExecutingAssembly();

    public override void OnInitializeMelon()
    {
        ModConsole.Setup(LoggerInstance);
        Preferences.Setup();
        Assets.Load();
        BoneMenu.Setup();
        Hooking.OnLevelUnloaded += OnLevelUnload;
#if DEBUG
        ModConsole.Warning("This is a debug build! It's possibly unstable.");
#endif
    }
    
    private static void OnLevelUnload()
    {
        // in case OnDestroy doesn't get called by unloading a scene
        Scanner.PostDestroy();
        BoneMenu.IsSpawned = false;
    }
}