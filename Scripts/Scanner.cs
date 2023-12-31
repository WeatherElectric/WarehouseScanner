
namespace WarehouseScanner.Scripts;

[RegisterTypeInIl2Cpp]
public class Scanner : MonoBehaviour
{
    public static Scanner Instance { get; private set; }
    
    private Transform _firePoint;
    private TextMeshPro _titleText;
    private TextMeshPro _barcodeText;

    private void Awake()
    {
        Instance = this;
    }
    
    private void Start()
    {
        // PLEASE CAN WE JUST MOVE ON TO ML 0.6 FOR BUILT-IN FIELDINJECTION
        // ALTERNATIVELY, CAM PLEASE GIVE ME THE MONO BUILD
        _firePoint = transform.Find("FirePoint");
        _titleText = transform.Find("Text/Title").GetComponent<TextMeshPro>();
        _barcodeText = transform.Find("Text/Barcode").GetComponent<TextMeshPro>();
    }

    public void Scan()
    {
        Physics.Raycast(_firePoint.position, _firePoint.forward, out var hit, 100f);
        // can raycasts just drown already?
        if (hit.rigidbody == null) return;
        var poolee = hit.rigidbody.gameObject.GetComponent<AssetPoolee>();
        // there used to be a dumb check here, it's dumb, I killed it, he wasn't a good employee anyways
        if (poolee == null) return;
        var barcode = poolee.spawnableCrate.Barcode;
        var title = poolee.spawnableCrate.Title;
        _titleText.text = title;
        _barcodeText.text = barcode;
        // i mean I can use a coroutine, buut i dont wanna make jevilib a dependency
        // hey look at me actually using comments, i never do this
        Invoke(nameof(HideText), 2f);
        ModConsole.Msg($"{poolee.gameObject.name}'s barcode: {barcode}, title: {title}");
    }

    private void HideText()
    {
        // NO! GO AWAY TEXT! FUCK YOU!
        _titleText.text = "";
        _barcodeText.text = "";
    }
    
    private void OnDestroy()
    {
        Instance = null;
    }
    
    // needed to register in il2cpp, otherwise useless
    public Scanner(IntPtr ptr) : base(ptr) {}
}