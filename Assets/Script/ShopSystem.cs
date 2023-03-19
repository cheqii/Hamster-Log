using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour
{
    [Header("Coins Currency")]
    [SerializeField] private TextMeshProUGUI totalCoinText;

    private CoinSystem coinSystem;
    private Items items;

    private void Start()
    {
        coinSystem = FindObjectOfType<CoinSystem>().GetComponent<CoinSystem>();
    }

    void AddItem(int id)
    {
        PlayerPrefs.SetInt(id.ToString(), 1);
        PlayerPrefs.SetInt("currentSkin",id);
    }

    public void Purchase(int id, int price, Items items)
    {
        if (coinSystem.TotalCoin >= price && PlayerPrefs.GetInt(id.ToString()) == 0)
        {
            Debug.Log("Purchased");
            coinSystem.DecreaseCoin(price);
            AddItem(id);
            items.PriceText.text = "Use";
        }
        else
        {
            if(coinSystem.TotalCoin < price) Debug.Log("Not enough coins");
            if(PlayerPrefs.GetInt(id.ToString()) == 1)
            {
                //items.PriceText.text = "Used";
                FindObjectOfType<Hamster>().ChangeHamsterSkin(items.HamsterSkins.hamssterImage,id);
                PlayerPrefs.SetInt("currentSkin",id);
                Debug.Log("Already purchased");
            }
        }
    }
    
    public void Purchase(int id, int price, int lv,GameObject lockPage)
    {
        if (coinSystem.TotalCoin >= price && PlayerPrefs.GetInt(id+10.ToString()) == 0)
        {
            Debug.Log("Purchased");
            coinSystem.DecreaseCoin(price);
            PlayerPrefs.SetInt(id.ToString()+10, 1);
            lockPage.SetActive(false);
        }
        else
        {
            if(coinSystem.TotalCoin < price) Debug.Log("Not enough coins");
            
            if(PlayerPrefs.GetInt(id.ToString()+10) == 1)
            {
                FindObjectOfType<LevelSelect>().GetComponent<LevelSelect>().ChangeLevel(lv);
            }
        }
    }
    

    public void UpdateCoin()
    {
        totalCoinText.text = coinSystem.TotalCoin.ToString();
    }

    public void ResetShop(int id)
    {
        PlayerPrefs.DeleteKey(id.ToString());
    }
}
