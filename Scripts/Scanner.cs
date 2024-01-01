// ReSharper disable UnassignedField.Global, they're serialized you dingus.
// ReSharper disable PossibleNullReferenceException, they're serialized you dingus.
namespace WarehouseScanner.Scripts;

[RegisterTypeInIl2Cpp]
public class Scanner : MonoBehaviour
{
    public static Scanner Instance { get; private set; }

    internal static void PostDestroy()
    {
        Instance = null;
    }
    
    // I FUCKIN LOVE BUILT IN FIELDINJECTION!
    public Il2CppReferenceField<Transform> FirePoint;
    public Il2CppReferenceField<AudioSource> SuccessSound;
    public Il2CppReferenceField<ImpactSFX> ImpactSfx;
    public Il2CppReferenceField<GameObject> TitleText;
    public Il2CppReferenceField<GameObject> BarcodeText;
    // EXCEPT THAT ITS MADE BY THE BEPIN LOSERS, GODDAMMIT
    private TextMeshPro _titleText;
    private TextMeshPro _barcodeText;

    private void Awake()
    {
        Instance = this;
    }
    
    private void Start()
    {
        // since this is a code mod I can put the game's mixers YEAA FUCK YOU SDK MODDERS I GET TO DO THIS!
        SuccessSound.Get().outputAudioMixerGroup = Audio.SFXMixer;
        ImpactSfx.Get().outputMixer = Audio.SFXMixer;
        // textmeshpro doesn't inherit from il2cppobject, so i have to find it from serialized gameobjects.
        _titleText = TitleText.Get().GetComponent<TextMeshPro>();
        _barcodeText = BarcodeText.Get().GetComponent<TextMeshPro>();
    }

    public void Scan()
    {
        var firepoint = FirePoint.Get();
        var successsound = SuccessSound.Get();
        Physics.Raycast(firepoint.position, firepoint.forward, out var hit, 100f);
        // can raycasts just drown already?
        if (hit.rigidbody == null) return;
        successsound.Play();
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