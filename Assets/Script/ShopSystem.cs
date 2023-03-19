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
            if(PlayerPrefs.GetInt(id.ToString()) == 1) Debug.Log("Already purchased");
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
