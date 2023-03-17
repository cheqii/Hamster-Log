using UnityEngine;

public class Magnet : MonoBehaviour
{
    [Header("Magnetic Settings")]
    [SerializeField] private static bool _isMagnetic;
    
    [Header("Magnetic Fields")]
    [SerializeField] private GameObject magneticField;
    // Start is called before the first frame update
    void Start()
    {
        //magneticField = GameObject.FindGameObjectWithTag("MagneticField");
        _isMagnetic = false;
        magneticField.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hamster get magnet");
            Destroy(this.gameObject);
            ActivateMagnet();
        }
    }

    void ActivateMagnet()
    { 
        if (_isMagnetic)
        {
            magneticField.SetActive(true);
            Invoke("ActivateMagnet", 10f);
            _isMagnetic = false;
            magneticField.SetActive(false);
        }
    }
}
