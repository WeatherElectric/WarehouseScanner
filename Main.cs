namespace WarehouseScanner;

public class Main : MelonMod
{
    internal const string Name = "WarehouseScanner";
    internal const string Description = "Scan crates, get barcodes.";
    internal const string Author = "SoulWithMae";
    internal const string Company = "Weather Electric";
    internal const string Version = "0.0.1";
    internal const string DownloadLink = null;

    public override void OnInitializeMelon()
    {
        ModConsole.Setup(LoggerInstance);
        Preferences.Setup();
        BoneMenu.Setup();
        Hooking.OnLevelUnloaded += OnLevelUnload;
    }
    
    private static void OnLevelUnload()
    {
        BoneMenu.IsSpawned = false;
    }
}