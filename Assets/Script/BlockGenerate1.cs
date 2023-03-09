using UnityEngine;

public class BlockGenerate1 : MonoBehaviour
{
    [SerializeField] private GameObject block;
    [SerializeField] private int stopOn;
    [SerializeField] private int currentBlock;
    public int index = 0;
    private GameObject objectToSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        if (index == GameData.Instance.GetObstacleDataLength())
        {
            index = 0;
        }

        GameObject objectToSpawn = new GameObject();
         objectToSpawn = GameData.Instance.GetObstacle(index);
        
        index++;
        
        Vector3 spawnRotation = new Vector3(
            objectToSpawn.transform.eulerAngles.x - 20f,
            objectToSpawn.transform.eulerAngles.y,
            objectToSpawn.transform.eulerAngles.z);
        
        if (currentBlock < stopOn)
        {
            
            Vector3 endpoint;
            endpoint = this.transform.position - transform.forward * 14;
            GameObject NewBlock = Instantiate(block, endpoint, transform.rotation);
            SetBlock(NewBlock);
            Instantiate(objectToSpawn, endpoint + (objectToSpawn.transform.up),Quaternion.Euler(spawnRotation));



        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void SetBlock(GameObject NewBlock)
    {
        NewBlock.GetComponent<BlockGenerate1>().stopOn = stopOn;
        NewBlock.GetComponent<BlockGenerate1>().block = block;
        NewBlock.GetComponent<BlockGenerate1>().currentBlock = currentBlock + 1;
        NewBlock.GetComponent<BlockGenerate1>().index = index;

    }
    
    
}
