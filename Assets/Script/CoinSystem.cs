using System;
using TMPro;
using UnityEngine;

public class CoinSystem : MonoBehaviour
{
    private Hamster hamster;
    
    [Header("Coin UI")]
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI totalCoinText;
    
    [Header("Coin Count")]
    [SerializeField] private int amountCoin;

    private void Awake()
    {
        hamster = FindObjectOfType<Hamster>().GetComponent<Hamster>();
    }

    public int AmountCoin
    {
        get => amountCoin;
        set => amountCoin = value;
    }
    
    [SerializeField] private int totalCoin;

    public int TotalCoin
    {
        get => totalCoin;
        set => totalCoin = value;
    }

    void Start()
    {
        totalCoin = PlayerPrefs.GetInt("TotalCoin", 0);
        totalCoinText.text = totalCoin.ToString();
    }

    public void CoinCollect()
    {
        Debug.Log("Coin Update");
        amountCoin += 1;
        coinText.text = amountCoin.ToString();
    }
    
    public void TotalCoinCount()
    {
        totalCoin += amountCoin;
        totalCoinText.text = totalCoin.ToString();
        PlayerPrefs.SetInt("TotalCoin", totalCoin);
    }
    
    public void DecreaseCoin(int value)
    {
        totalCoin -= value;
        totalCoinText.text = totalCoin.ToString();
        PlayerPrefs.SetInt("TotalCoin", totalCoin);
    }
    
    public void IncreaseCoin(int value)
    {
        totalCoin += value;
        totalCoinText.text = totalCoin.ToString();
        PlayerPrefs.SetInt("TotalCoin", totalCoin);
    }
}
