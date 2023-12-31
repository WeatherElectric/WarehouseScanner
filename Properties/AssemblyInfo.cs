[assembly: AssemblyTitle(WarehouseScanner.Main.Description)]
[assembly: AssemblyDescription(WarehouseScanner.Main.Description)]
[assembly: AssemblyCompany(WarehouseScanner.Main.Company)]
[assembly: AssemblyProduct(WarehouseScanner.Main.Name)]
[assembly: AssemblyCopyright("Developed by " + WarehouseScanner.Main.Author)]
[assembly: AssemblyTrademark(WarehouseScanner.Main.Company)]
[assembly: AssemblyVersion(WarehouseScanner.Main.Version)]
[assembly: AssemblyFileVersion(WarehouseScanner.Main.Version)]
[assembly:
    MelonInfo(typeof(WarehouseScanner.Main), WarehouseScanner.Main.Name, WarehouseScanner.Main.Version,
        WarehouseScanner.Main.Author, WarehouseScanner.Main.DownloadLink)]
[assembly: MelonColor(ConsoleColor.Magenta)]

// Create and Setup a MelonGame Attribute to mark a Melon as Universal or Compatible with specific Games.
// If no MelonGame Attribute is found or any of the Values for any MelonGame Attribute on the Melon is null or empty it will be assumed the Melon is Universal.
// Values for MelonGame Attribute can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame("Stress Level Zero", "BONELAB")]