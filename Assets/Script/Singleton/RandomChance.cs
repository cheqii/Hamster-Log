using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RandomChance : MonoBehaviour
{
    public static RandomChance Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    public int GetRandomChance(int[] allChance)
    {
        int percents = 0;
        int index = 0;
        int randomNum = 0;
        
        randomNum = Random.Range(0, 100);

        
        int[] item = new int[allChance.Length];
        
        foreach (var i in allChance)
        {
            percents += i;
            item[index] = percents;
            index++;
        }

        for (int i = 0; i < item.Length ; i++)
        {
            if (Check(item[i], randomNum))
            {
                return i;
            }
        }
        
        return 9999;
    }
    
    private bool Check ( int range, int randomNum)
    {
        bool inRange;
            
        if (randomNum < range)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }
        // Debug.Log("range : " + range + "is " + inRange);

        return inRange;
    }
    
    
}
