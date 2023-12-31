using WarehouseScanner.Scripts;

namespace WarehouseScanner.Menu;

internal static class BoneMenu
{
    public static bool IsSpawned;
    public static void Setup()
    {
        MenuCategory mainCat = MenuManager.CreateCategory("Weather Electric", "#6FBDFF");
        MenuCategory subCat = mainCat.CreateCategory("Warehouse Scanner", Color.magenta);
        subCat.CreateFunctionElement("Spawn", Color.green, Spawn);
        subCat.CreateFunctionElement("Despawn", Color.red, Despawn);
    }

    private static void Spawn()
    {
        if (IsSpawned) return;
        var location = Player.playerHead.forward * 2f;
        Object.Instantiate(Assets.Scanner, location, Quaternion.identity);
        IsSpawned = true;
    }
    
    private static void Despawn()
    {
        if (!IsSpawned) return;
        // IM SO SMART I KNEW THE INSTANCE WOULD BE USEFUL
        Object.Destroy(Scanner.Instance.gameObject);
        IsSpawned = false;
    }
}