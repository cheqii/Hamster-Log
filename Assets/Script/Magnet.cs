using System;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    // [Header("Magnetic Settings")]
    // public static bool Instance { get; private set; }
    
    //[Header("Magnetic Fields")]
    //[SerializeField] private GameObject magneticField;
    // Start is called before the first frame update

    // [Header("Magnetic Fields")]
    //
    // [SerializeField] private bool isMagnetic;
    //
    // public bool IsMagnetic
    // {
    //     get => isMagnetic;
    //     set => isMagnetic = value;
    // }
    //
    // private void Start()
    // {
    //     isMagnetic = false;
    //     this.gameObject.SetActive(false);
    // }

    private Hamster hamster;

    private void Start()
    {
        hamster = GameObject.Find("Hamster").GetComponent<Hamster>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Magnet"))
        {
            Debug.Log("Hamster get magnet");
            hamster.IsMagnetic = true;
            //isMagnetic = true;
            ActivateMagnet();
            Destroy(other.gameObject);
        }
    }

    void ActivateMagnet()
    {

        if (hamster.IsMagnetic)
        {
            Debug.Log("magnet in hamster");
            this.gameObject.SetActive(true);
            Invoke("ActivateMagnet", 5f);
            this.gameObject.SetActive(false);
        }
        // if (isMagnetic)
        // {
        //     Debug.Log("MagneticField is already active");
        //     this.gameObject.SetActive(true);
        //     Invoke("ActivateMagnet", 5f);
        //     isMagnetic = false;
        //     this.gameObject.SetActive(false);
        // }
        
        
        // if (_isMagnetic)
        // {
        //     Debug.Log("Magnet Activated");
        //     //magneticField.gameObject.SetActive(true);
        //     Invoke("ActivateMagnet", 10f);
        //     _isMagnetic = false;
        //     //magneticField.SetActive(false);
        // }
        
    }
}
