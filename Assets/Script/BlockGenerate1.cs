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
        GameObject objectToSpawn = GameData.Instance.GetObstacle(index);
        index++;
        
        objectToSpawn.transform.eulerAngles = new Vector3(
            -20f,
            objectToSpawn.transform.eulerAngles.y,
            objectToSpawn.transform.eulerAngles.z);
        
        if (currentBlock < stopOn)
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y - 4.88f,
                transform.position.z - 13.33f);
            GameObject NewBlock = Instantiate(block, pos, transform.rotation);
            SetBlock(NewBlock);


            Instantiate(objectToSpawn, pos + (objectToSpawn.transform.up),objectToSpawn.transform.rotation);
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
