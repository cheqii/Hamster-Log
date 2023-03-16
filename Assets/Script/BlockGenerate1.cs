using UnityEngine;

public class BlockGenerate1 : MonoBehaviour
{
    [SerializeField] private GameObject block;
    [SerializeField] private GameObject leftBlock;
    [SerializeField] private GameObject rightBlock;
    [SerializeField] private int stopOn;
    [SerializeField] private int currentBlock;
    [SerializeField] private bool isSpawnObstacle = true;
    private GameObject objectToSpawn;
    
    
    // Start is called before the first frame update
    void Start()
    {

        if (currentBlock < stopOn)
        {
            Vector3 endpoint;
            endpoint = this.transform.position - transform.forward * transform.localScale.z;
            GameObject NewBlock = Instantiate(block, endpoint, transform.rotation);
            SetBlock(NewBlock);

            if (Random.Range(1, 100) < 5)
            {

                if (Random.Range(1, 3) == 1)
                {
                    NewBlock.transform.position = new Vector3(
                        NewBlock.transform.position.x + NewBlock.transform.localScale.x,
                        NewBlock.transform.position.y,
                        NewBlock.transform.position.z);
                    
                    Instantiate(rightBlock, endpoint, transform.rotation);

                }
                else
                {
                    NewBlock.transform.position = new Vector3(
                        NewBlock.transform.position.x - NewBlock.transform.localScale.x,
                        NewBlock.transform.position.y,
                        NewBlock.transform.position.z);
                    
                    Instantiate(leftBlock, endpoint, transform.rotation);

                }
            }


            int loop;
            loop = Random.Range(0, GameData.Instance.GetObstacleMaxSpawn());

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
                        RandomChance.Instance.GetRandomChance(GameData.Instance.GetObstacleChance()));

                    Vector3 spawnRotation = new Vector3(
                        objectToSpawn.transform.eulerAngles.x - 20f,
                        objectToSpawn.transform.eulerAngles.y,
                        objectToSpawn.transform.eulerAngles.z);
                    //chance of spawn
                    if (GameData.Instance.GetObstacleSpawnChance() > (Random.Range(0, 100)))
                    {
                        GameObject Obstacle = Instantiate(objectToSpawn, objectSpawnPoint, Quaternion.Euler(spawnRotation));
                        Obstacle.AddComponent<RaycastPositionSet>();
                        
                    }
                }
            }
            
        }
        
        
    }


    void SetBlock(GameObject NewBlock)
    {
        NewBlock.GetComponent<BlockGenerate1>().stopOn = stopOn;
        NewBlock.GetComponent<BlockGenerate1>().block = block;
        NewBlock.GetComponent<BlockGenerate1>().currentBlock = currentBlock + 1;

    }
    
    
}
