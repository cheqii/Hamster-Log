using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Obstacle", order = 1)]
public class Obstacle : ScriptableObject
{
    [Header("ObstacleInThisLevel")]
    public GameObject[] Objects;
    
    [Header("Goal")]
    public GameObject EndSlope;
    
    [Header("ChanceOfObstacle")]
    public int[] ObstacleChance;
    
 
    
    [Header("ChanceOfSpawningObstacle (percent)")]
    public int SpawnChance;
    
    [Header("NumberOfMaxObstacle")]
    public int MaxSpawn;
    
    [Header("laneSwitchPercent")]
    public int laneSwitchPercent = 5;
    
    [Header("invisible ground")]
    public GameObject invisibleGround;

}