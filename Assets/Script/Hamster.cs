using System;
using UnityEngine;

public class Hamster : MonoBehaviour
{

    [SerializeField] private GameObject hamster;
    [SerializeField] private GameObject blood;
    [SerializeField] private LogControl _logControl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HamsterDie()
    {
        Debug.Log("Hamster is dead");
        Instantiate(blood, hamster.transform.position, hamster.transform.rotation);
        Destroy(hamster);
        Destroy(_logControl);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("ground")) HamsterDie();
        
        if(other.gameObject.CompareTag("Obstacle")) HamsterDie();
    }
    
}
