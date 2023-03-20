using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LevelData", order = 1)]
public class LevelData : ScriptableObject
{
    [Header("LevelDistance (block)")]
    public int LevelDistance;
    
    [Header("ObstacleInThisLevel")]
    public GameObject[] Objects;

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
    
    [Header("Goal")]
    public GameObject EndSlope;
    
    [Header("Skybox")]
    public Material _Skybox;
    
    [Header("Enemy")]
    public GameObject _enemy;

}