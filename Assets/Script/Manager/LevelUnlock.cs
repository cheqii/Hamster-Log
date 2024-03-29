using TMPro;
using UnityEngine;

public class LevelUnlock : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private int lv;
    [SerializeField] private int price;
    [SerializeField] private GameObject lockPage;
    
    // Start is called before the first frame update
    void Start()
    {
        //coinSystem = FindObjectOfType<CoinSystem>().GetComponent<CoinSystem>();
        priceText.text = "Unlock for " + price + " $";

        LoadShopData();

    }
    
    
    public void UnlockLevel()
    {
        FindObjectOfType<ShopSystem>().Purchase(lv, price, lv,lockPage,priceText );
    }
    
    void LoadShopData()
    {

        if(PlayerPrefs.GetInt((lv+10).ToString() , 0) == 1)
        {
            lockPage.gameObject.SetActive(false); ;
            priceText.text = "Play!";
        }
        else
        {
            lockPage.gameObject.SetActive(true); ;
        }
    }
}
