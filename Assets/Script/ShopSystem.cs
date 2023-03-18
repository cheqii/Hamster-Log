using System;
using TMPro;
using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    [Header("Coins Currency")]
    [SerializeField] private TextMeshProUGUI totalCoinText;

    private CoinSystem coinSystem;

    private void Awake()
    {
        // coinSystem = FindObjectOfType<CoinSystem>().GetComponent<CoinSystem>();
    }

    private void Start()
    {
        coinSystem = FindObjectOfType<CoinSystem>().GetComponent<CoinSystem>();
        totalCoinText.text = coinSystem.TotalCoin.ToString();
    }

    private void Update()
    {
        totalCoinText.text = coinSystem.TotalCoin.ToString();
        // Purchase();
    }
    

    public void Purchase()
    {
        
    }
}
