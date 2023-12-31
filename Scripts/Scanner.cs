namespace WarehouseScanner.Scripts;

[RegisterTypeInIl2Cpp]
public class Scanner : MonoBehaviour
{
    public static Scanner Instance { get; private set; }
    
    private Transform _firePoint;

    private void Awake()
    {
        Instance = this;
    }
    
    private void Start()
    {
        _firePoint = transform.Find("FirePoint");
    }

    public void Scan()
    {
        Physics.Raycast(_firePoint.position, _firePoint.forward, out var hit, 100f);
        var poolee = hit.rigidbody.gameObject.GetComponent<AssetPoolee>();
        if (poolee == null)
        {
            poolee = hit.transform.GetComponentInParent<AssetPoolee>();
        }
        var barcode = poolee.spawnableCrate.Barcode;
        var title = poolee.spawnableCrate.Title;
        ModConsole.Msg($"{poolee.gameObject.name}'s barcode: {barcode}, title: {title}");
    }
    
    private void OnDestroy()
    {
        Instance = null;
    }
    
    public Scanner(IntPtr ptr) : base(ptr) {}
}