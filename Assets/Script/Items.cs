using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour
{
    [Header("HamsterSkin Data")]
    [SerializeField] private HamsterSkins hamsterSkins;
    [SerializeField] private Image hamsterSprites;
    [SerializeField] private TextMeshProUGUI priceText;
    public TextMeshProUGUI PriceText
        {
            get => priceText;
            set => priceText = value;
        }
    
    public HamsterSkins HamsterSkins
    {
        get => hamsterSkins;
        set => hamsterSkins = value;
    }
    
    [SerializeField] private Button button;

    private CoinSystem coinSystem;

    private void Start()
    {
        coinSystem = FindObjectOfType<CoinSystem>().GetComponent<CoinSystem>();
        button.GetComponent<Image>().color = Color.green;
        LoadShopData();
    }

    private void Update()
    {
        if(coinSystem.TotalCoin >= hamsterSkins.price) button.GetComponent<Image>().color = Color.green;
        if(coinSystem.TotalCoin < hamsterSkins.price && PlayerPrefs.GetInt(hamsterSkins.ID.ToString(), 0) == 0) button.GetComponent<Image>().color = Color.red;
        
    }

    void LoadShopData()
    {
        if(PlayerPrefs.GetInt(hamsterSkins.ID.ToString() , 0) == 1)
        {
            Debug.Log("Have Items");
            hamsterSprites.sprite = hamsterSkins.hamssterImage;
            priceText.text = "Use";
        }
        else
        {
            hamsterSprites.sprite = hamsterSkins.hamssterImage;
            priceText.text = "Unlock " + hamsterSkins.price.ToString() + " $";
        }
    }
    
    public void UnlockHamster()
    {
        FindObjectOfType<ShopSystem>().Purchase(hamsterSkins.ID, hamsterSkins.price, this);
    }
}
