using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance { get; private set; }
    [SerializeField] private LevelData[] _levelDatas;



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
        return _levelDatas[level].Objects[index];
    }
    
    public int[] GetObstacleChance(int level)
    {
        return _levelDatas[level].ObstacleChance;
    }
    public int GetObstacleSpawnChance(int level)
    {
        return _levelDatas[level].SpawnChance;
    }
    public int GetObstacleMaxSpawn(int level)
    {
        return _levelDatas[level].MaxSpawn;
    }
    
    public int GetObstacleDataLength(int level)
    {
        return _levelDatas[level].Objects.Length;
    }
    
    public int GetLaneSwitch(int level)
    {
        return _levelDatas[level].laneSwitchPercent;
    }
    
    public GameObject GetEndSlope(int level)
    {
        return _levelDatas[level].EndSlope;
    }
    
    public GameObject GetInvisible(int level)
    {
        return _levelDatas[level].invisibleGround;
    }
    
    public int GetLevelDistance(int level)
    {
        return _levelDatas[level].LevelDistance;
    }

    public Material GetSkybox(int level)
    {
        return _levelDatas[level]._Skybox;
    }
    
    public GameObject GetEnemy(int level)
    {
        return _levelDatas[level]._enemy;
    }
}
