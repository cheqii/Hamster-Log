using UnityEngine;

public class ItemMagnetic : MonoBehaviour
{
    [Header("Magnetic Settings")]
    [SerializeField] private bool itemIsMagnetic;
    [SerializeField] private float magneticForce;
    
    [Header("Magnetic Objects")]
    private Rigidbody rb; // item rigidbody
    private GameObject hamster; // player rigidbody
    private Vector3 direction; // direction from item to player

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hamster = GameObject.FindGameObjectWithTag("Player");
        itemIsMagnetic = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Attract();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MagneticField"))
        {
            itemIsMagnetic = true;
        }
    }
    void Attract()
    {
        if (itemIsMagnetic)
        {
            Debug.Log("Item is magnetic");
            direction = -(rb.transform.position - hamster.transform.position).normalized; 
            rb.velocity = new Vector3(direction.x, direction.y, direction.z) * (magneticForce * Time.deltaTime);
        }
    }
}
