using UnityEngine;

public class ItemMagnetic : MonoBehaviour
{
    [Header("Magnetic Settings")]
    [SerializeField] private bool isMagnetic;
    
    [Header("Magnetic Fields")]
    [SerializeField] private GameObject magneticField;
    // Start is called before the first frame update
    void Start()
    {
        //magneticField = GameObject.FindGameObjectWithTag("MagneticField");
        magneticField.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ActivateMagnet();
        }
    }

    void ActivateMagnet()
    { 
        if (isMagnetic)
        {
            magneticField.SetActive(true);
            Invoke("ActivateMagnet", 10f);
            isMagnetic = false;
            magneticField.SetActive(false);
        }
    }
}
