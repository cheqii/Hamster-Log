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
        LoadShopData();
        priceText.text = "Unlock for " + price + " $";

    }
    
    
    public void UnlockLevel()
    {
        FindObjectOfType<ShopSystem>().Purchase(lv, price, lv,lockPage );
    }
    
    void LoadShopData()
    {

        if(PlayerPrefs.GetInt((lv+10).ToString() , 0) == 1)
        {
           

            lockPage.gameObject.SetActive(false); ;
        }
        else
        {
            lockPage.gameObject.SetActive(true); ;
        }
    }
}
