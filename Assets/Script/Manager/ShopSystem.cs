using TMPro;
using UnityEngine;

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
            SoundManager.Instance.PlayBuy();

        }
        else
        {
            if(coinSystem.TotalCoin < price) Debug.Log("Not enough coins");
            if(PlayerPrefs.GetInt(id.ToString()) == 1)
            {
                FindObjectOfType<Hamster>().ChangeHamsterSkin(items.HamsterSkins.hamssterImage,id);
                PlayerPrefs.SetInt("currentSkin",id);
                Debug.Log("Change Skin");
                SoundManager.Instance.PlayChangeCharactor();
            }
        }
    }
    
    public void Purchase(int id, int price, int lv,GameObject lockPage,TextMeshProUGUI priceText)
    {
        if (coinSystem.TotalCoin >= price && PlayerPrefs.GetInt((id+10).ToString()) == 0)
        {
            Debug.Log("Purchased");
            coinSystem.DecreaseCoin(price);
            PlayerPrefs.SetInt((id+10).ToString(), 1);
            lockPage.SetActive(false);
            SoundManager.Instance.PlayUnlock();
            priceText.text = "Play!";
        }
        else
        {
            if(coinSystem.TotalCoin < price) Debug.Log("Not enough coins");
            
            if(PlayerPrefs.GetInt((id+10).ToString()) == 1)
            {
                FindObjectOfType<LevelSelect>().GetComponent<LevelSelect>().ChangeLevel(lv);
                FindObjectOfType<UIManager>().GetComponent<UIManager>().StartGame();
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
