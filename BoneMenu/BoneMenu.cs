namespace WarehouseScanner.Menu;

internal static class BoneMenu
{
    public static bool IsSpawned;
    public static void Setup()
    {
        MenuCategory mainCat = MenuManager.CreateCategory("Weather Electric", "#6FBDFF");
        MenuCategory subCat = mainCat.CreateCategory("Warehouse Scanner", Color.red);
        subCat.CreateFunctionElement("Spawn", Color.green, Spawn);
        subCat.CreateFunctionElement("Despawn", Color.red, Despawn);
    }

    private static void Spawn()
    {
        if (IsSpawned) return;
        // Fill these out when bundle's set up
        IsSpawned = true;
    }
    
    private static void Despawn()
    {
        if (!IsSpawned) return;
        // Fill these out when bundle's set up
        IsSpawned = false;
    }
}