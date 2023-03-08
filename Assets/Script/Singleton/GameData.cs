using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance { get; private set; }
    [SerializeField] private Obstacle _obstacle;

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
    

    public GameObject GetObstacle(int index)
    {
        return _obstacle.Objects[index];
    }
    
    public int GetObstacleDataLength()
    {
        return _obstacle.Objects.Length;
    }
    
}
