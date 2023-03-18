using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ShopData", menuName = "ScriptableObjects/HamsterSkins", order = 1)]
public class HamsterSkins : ScriptableObject
{
    public Sprite hamssterImage;

    public int ID;
    
    public int price;
}