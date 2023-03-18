using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance { get; private set; }
    [SerializeField] private Obstacle[] _obstacle;



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
    

    public GameObject GetObstacle(int index,int level)
    {
        return _obstacle[level].Objects[index];
    }
    
    public int[] GetObstacleChance(int level)
    {
        return _obstacle[level].ObstacleChance;
    }
    public int GetObstacleSpawnChance(int level)
    {
        return _obstacle[level].SpawnChance;
    }
    public int GetObstacleMaxSpawn(int level)
    {
        return _obstacle[level].MaxSpawn;
    }
    
    public int GetObstacleDataLength(int level)
    {
        return _obstacle[level].Objects.Length;
    }
    
    public int GetLaneSwitch(int level)
    {
        return _obstacle[level].laneSwitchPercent;
    }
    
}
