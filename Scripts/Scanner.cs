namespace WarehouseScanner.Scripts;

[RegisterTypeInIl2Cpp]
public class Scanner : MonoBehaviour
{
    public static Scanner? Instance { get; private set; }

    internal static void PostDestroy()
    {
        Instance = null;
    }
    
    public Transform firePoint;
    public AudioSource successSound;
    public ImpactSFX impactSfx;
    public TextMeshPro TitleText;
    public TextMeshPro BarcodeText;

    private void Awake()
    {
        Instance = this;
    }
    
    private void Start()
    {
        // since this is a code mod I can put the game's mixers YEAA FUCK YOU SDK MODDERS I GET TO DO THIS!
        successSound.outputAudioMixerGroup = Audio.SFXMixer;
        impactSfx.outputMixer = Audio.SFXMixer;
    }

    public void Scan()
    {
        Physics.Raycast(firePoint.position, firePoint.forward, out var hit, 100f);
        // can raycasts just drown already?
        if (hit.rigidbody == null) return;
        successSound.Play();
        var poolee = hit.rigidbody.gameObject.GetComponent<AssetPoolee>();
        // there used to be a dumb check here, it's dumb, I killed it, he wasn't a good employee anyways
        if (poolee == null) return;
        var barcode = poolee.spawnableCrate.Barcode;
        var title = poolee.spawnableCrate.Title;
        TitleText.text = title;
        BarcodeText.text = barcode;
        // i mean I can use a coroutine, buut i dont wanna make jevilib a dependency
        // hey look at me actually using comments, i never do this
        Invoke(nameof(HideText), 2f);
        ModConsole.Msg($"{poolee.gameObject.name}'s barcode: {barcode}, title: {title}");
    }

    private void HideText()
    {
        // NO! GO AWAY TEXT! FUCK YOU!
        TitleText.text = "";
        BarcodeText.text = "";
    }
    
    private void OnDestroy()
    {
        Instance = null;
    }
    
    // needed to register in il2cpp, otherwise useless
    public Scanner(IntPtr ptr) : base(ptr) {}
}