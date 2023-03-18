using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Items : MonoBehaviour
{
    [Header("HamsterSkin Data")]
    [SerializeField] private HamsterSkins hamsterSkins;
    
    [SerializeField] private Sprite hamsterSprites;
    [SerializeField] private int hamsterPrices;
    [SerializeField] private TextMeshProUGUI priceText;

    private void Start()
    {
        hamsterSprites = hamsterSkins.hamssterImage;
        hamsterPrices = hamsterSkins.price;
        priceText.text = hamsterSkins.price.ToString();
    }
}
