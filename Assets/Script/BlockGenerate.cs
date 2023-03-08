using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class BlockGenerate : MonoBehaviour
{
    [SerializeField] private GameObject block;
    [SerializeField] private int stopOn;
    [SerializeField] private int currentBlock;
    
    // Start is called before the first frame update
    void Start()
    {
        if (currentBlock < stopOn)
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y - 4.88f,
                transform.position.z - 13.33f);
            GameObject NewBlock = Instantiate(block, pos, transform.rotation);
            SetBlock(NewBlock);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetBlock(GameObject NewBlock)
    {
        NewBlock.GetComponent<BlockGenerate>().stopOn = stopOn;
        NewBlock.GetComponent<BlockGenerate>().block = block;
        NewBlock.GetComponent<BlockGenerate>().currentBlock = currentBlock + 1;
        
    }
}
