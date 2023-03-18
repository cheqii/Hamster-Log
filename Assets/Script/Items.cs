using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour
{
    [Header("HamsterSkin Data")]
    [SerializeField] private HamsterSkins hamsterSkins;
    
    [SerializeField] private Image hamsterSprites;
    [SerializeField] private int hamsterPrices;
    [SerializeField] private TextMeshProUGUI priceText;

    public TextMeshProUGUI PriceText
    {
        get => priceText;
        set => priceText = value;
    }
    private void Start()
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
        FindObjectOfType<ShopSystem>().Purchase(hamsterSkins.ID, hamsterPrices, this);
    }
}
