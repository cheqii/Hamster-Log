using UnityEngine;

public class BlockGenerate : MonoBehaviour
{
    [SerializeField] private int level;
    
    [SerializeField] private GameObject block;
    [SerializeField] private GameObject leftBlock;
    [SerializeField] private GameObject rightBlock;
    [SerializeField] private int stopOn;
    [SerializeField] private int currentBlock;
    [SerializeField] private int laneSwitchPercent = 5;
    [SerializeField] private bool isSpawnObstacle = true;

    [SerializeField] private bool isStartSlope = false;
    private GameObject objectToSpawn;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        if (isStartSlope == false)
        {
            GenerateLevel();
        }
    }

    public void GenerateLevel()
    {
        
        if (currentBlock < stopOn)
        {
            Vector3 endpoint;
            Vector3 gap = new Vector3(0, 0.1f, 0);
            endpoint = this.transform.position - transform.forward * transform.localScale.z - gap;
            GameObject NewBlock = Instantiate(block, endpoint, transform.rotation);
            SetBlock(NewBlock);
            
            //invisible ground
            
            GameObject IG = Instantiate(GameData.Instance.GetInvisible(level), endpoint + (Vector3.down*5), transform.rotation);


            if (Random.Range(1, 100) < laneSwitchPercent && isSpawnObstacle == true)
            {

                if (Random.Range(1, 3) == 1)
                {
                    NewBlock.transform.position = new Vector3(
                        NewBlock.transform.position.x + NewBlock.transform.localScale.x,
                        NewBlock.transform.position.y,
                        NewBlock.transform.position.z);
                    
                    //Instantiate(rightBlock, endpoint, transform.rotation);

                }
                else
                {
                    NewBlock.transform.position = new Vector3(
                        NewBlock.transform.position.x - NewBlock.transform.localScale.x,
                        NewBlock.transform.position.y,
                        NewBlock.transform.position.z);
                    
                    //Instantiate(leftBlock, endpoint, transform.rotation);

                }
            }


            int loop;
            loop = Random.Range(0, GameData.Instance.GetObstacleMaxSpawn(level));

            if (isSpawnObstacle)
            {
                for (int i = 0; i < loop; i++)
                {
                    Vector3 objectSpawnPoint = new Vector3(NewBlock.transform.position.x +
                                                           Random.Range(-transform.localScale.x / 2,
                                                               transform.localScale.x / 2),
                        NewBlock.transform.position.y + 10,
                        NewBlock.transform.position.z +
                        Random.Range(-transform.localScale.z / 2, transform.localScale.z / 2));
                
                
                    objectToSpawn = GameData.Instance.GetObstacle(
                        RandomChance.Instance.GetRandomChance(GameData.Instance.GetObstacleChance(level)),level);

                    Vector3 spawnRotation = new Vector3(
                        objectToSpawn.transform.eulerAngles.x - 20f,
                        objectToSpawn.transform.eulerAngles.y,
                        objectToSpawn.transform.eulerAngles.z);
                    //chance of spawn
                    if (GameData.Instance.GetObstacleSpawnChance(level) > (Random.Range(0, 100)))
                    {
                        GameObject Obstacle = Instantiate(objectToSpawn, objectSpawnPoint, Quaternion.Euler(spawnRotation));
                        Obstacle.AddComponent<RaycastPositionSet>();
                        
                    }
                }
            }
            
        }
        else
        {
            Vector3 endpoint;
            Vector3 gap = new Vector3(0, 0.1f, 0);
            endpoint = this.transform.position - transform.forward * transform.localScale.z - gap;
            GameObject EndBlock = Instantiate(GameData.Instance.GetEndSlope(level), endpoint, transform.rotation);

        }
    }


    void SetBlock(GameObject NewBlock)
    {
        NewBlock.GetComponent<BlockGenerate>().stopOn = stopOn;
        NewBlock.GetComponent<BlockGenerate>().block = block;
        NewBlock.GetComponent<BlockGenerate>().currentBlock = currentBlock + 1;
        NewBlock.GetComponent<BlockGenerate>().level = level;
        NewBlock.GetComponent<BlockGenerate>().isStartSlope = false;

    }

    public void SetLevel(int lv,int lane,int dist)
    {
        this.level = lv;
        laneSwitchPercent = lane;
        stopOn = dist;
    }
    
    
    
}
