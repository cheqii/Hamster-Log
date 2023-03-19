using UnityEngine;

public class Hamster : MonoBehaviour
{
    [SerializeField] private GameObject hamster;
    [SerializeField] private GameObject blood;
    [SerializeField] private LogControl _logControl;
    
    [Header("Magnetic Fields")]
    [SerializeField] private Magnet magnet;
    
    [SerializeField] private CoinSystem coinSystem;
    
    [SerializeField] private HamsterSkins[] skins;
    private SpriteRenderer HamsterSkin;


    public void HamsterDie()
    {
        Debug.Log("Hamster is dead");
        coinSystem.TotalCoinCount(); // to counting all coins
        Instantiate(blood, hamster.transform.position, hamster.transform.rotation);
        Destroy(hamster);
        Destroy(_logControl);
        Destroy(_logControl.GetComponent<GroundCheck>());
        Destroy(magnet);
        Destroy(this.gameObject);
        SoundManager.Instance.StopSound();
        SoundManager.Instance.PlayHamsterDie();
    }

    private void Awake()
    {
        PlayerPrefs.SetInt("0", 1);
    }

    private void Start()
    {
        HamsterSkin = GetComponent<SpriteRenderer>();
        int currentSkin = PlayerPrefs.GetInt("currentSkin",0);
        ChangeHamsterSkin(skins[currentSkin].hamssterImage,currentSkin);
    }

    public void ChangeHamsterSkin(Sprite skin,int ID)
    {
        if (PlayerPrefs.GetInt(ID.ToString()) == 1)
        {
            HamsterSkin.sprite = skin;
        }
        else
        {
            Debug.Log("shit");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("ground"))
        {
            HamsterDie();
        }
        
        if(other.gameObject.CompareTag("Obstacle")) HamsterDie();
        
        if(other.gameObject.CompareTag("InvisibleGround")) HamsterDie();
        
        if(other.CompareTag("Magnet"))
        {
            Destroy(other.gameObject);// destroy the magnet
            magnet.Ismagnetic = true;
            StartCoroutine(magnet.MagnetActivate());
            SoundManager.Instance.PlayTakeMagmnet();
        }

        if (other.CompareTag("Coin"))
        {
            Debug.Log("Get Coin");
            Destroy(other.gameObject);
            coinSystem.CoinCollect();
            SoundManager.Instance.PlayTakeCoin();
        }
    }
}
