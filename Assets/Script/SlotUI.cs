using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotUI : MonoBehaviour
{
    private ShopSystem shopSystem;
    // Start is called before the first frame update
    void Start()
    {
        shopSystem = FindObjectOfType<ShopSystem>().GetComponent<ShopSystem>();
    }
    
}
