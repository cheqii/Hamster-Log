using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Obstacle", order = 1)]
public class Obstacle : ScriptableObject
{
    [Header("ObstacleInThisLevel")]
    public GameObject[] Objects;
    
    [Header("ChanceOfObstacle")]
    public int[] ObstacleChance;
    
    [Header("ChanceOfSpawningObstacle (percent)")]
    public int SpawnChance;
    
    [Header("NumberOfMaxObstacle")]
    public int MaxSpawn;

}