﻿using System.Reflection;

namespace WarehouseScanner;

public class Main : MelonMod
{
    internal const string Name = "WarehouseScanner";
    internal const string Description = "Scan crates, get barcodes.";
    internal const string Author = "SoulWithMae";
    internal const string Company = "Weather Electric";
    internal const string Version = "0.0.1";
    internal const string DownloadLink = null;
    
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
        BoneMenu.IsSpawned = false;
    }
}