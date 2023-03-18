using System;
using UnityEngine;

public class Hamster : MonoBehaviour
{
    [SerializeField] private GameObject hamster;
    [SerializeField] private GameObject blood;
    [SerializeField] private LogControl _logControl;
    
    [Header("Magnetic Fields")]
    [SerializeField] private GameObject magneticField;

    public GameObject MagneticField
    {
        get => magneticField;
        set => magneticField = value;
    }

    private bool isMagnetic;

    public bool IsMagnetic
    {
        get => isMagnetic;
        set => isMagnetic = value;
    }

    private void Start()
    {
        magneticField = GameObject.FindGameObjectWithTag("MagneticField");
    }

    public void HamsterDie()
    {
        Debug.Log("Hamster is dead");
        Instantiate(blood, hamster.transform.position, hamster.transform.rotation);
        Destroy(hamster);
        Destroy(_logControl);
        Destroy(_logControl.GetComponent<GroundCheck>());
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("ground")) HamsterDie();
        
        if(other.gameObject.CompareTag("Obstacle")) HamsterDie();
        
        if(other.gameObject.CompareTag("InvisibleGround")) HamsterDie();
        
        if(other.CompareTag("Magnet")) magneticField.SetActive(true);
    }
    
}
