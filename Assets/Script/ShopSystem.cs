using TMPro;
using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    [Header("Coins Currency")]
    [SerializeField] private TextMeshProUGUI totalCoinText;

    private CoinSystem coinSystem;

    private void Start()
    {
        coinSystem = FindObjectOfType<CoinSystem>().GetComponent<CoinSystem>();
        totalCoinText.text = coinSystem.TotalCoin.ToString();
    }

    private void Update()
    {
        totalCoinText.text = coinSystem.TotalCoin.ToString();
    }

    void AddItem(int id)
    {
        PlayerPrefs.SetInt(id.ToString(), 1);
    }

    public void Purchase(int id, int price, Items items)
    {
        if (coinSystem.TotalCoin >= price)
        {
            coinSystem.DecreaseCoin(price);
            AddItem(id);
            items.PriceText.text = "Use";
        }
    }

    public void ResetShop(int id)
    {
        PlayerPrefs.DeleteKey(id.ToString());
    }
}
