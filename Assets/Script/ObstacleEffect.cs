using UnityEngine;

public class ObstacleEffect : MonoBehaviour
{
    [Header("Jump Effect")]
    [SerializeField] private int jumpPadForce = 10;
    [SerializeField] private bool jumpEffect;

    [Header("Spin Effect")]
    [SerializeField] private float spinTorque = 0.5f;
    [SerializeField] private bool spinEffect;


    [Header("Speed Effect")] 
    [SerializeField] private float speedBoots = 8;
    [SerializeField] private bool speedEffect;
    
    [Header("TurnBack Effect")]
    [SerializeField] private float turnBackForce = 50;
    [SerializeField] private bool slowEffect;

    #region -Obstacle Effects-

    public void JumpBoots(GameObject player, int force)
    {
        if (jumpEffect)
        {
            
            if(this.gameObject.GetComponent<Collider>().isTrigger == true)
            {
                Debug.Log("Jump Triggered");
                player.GetComponent<Rigidbody>().AddForce(Vector3.up * force, ForceMode.Impulse);
            }
            else
            {
                Debug.Log("Jump Collision");
                player.GetComponent<Rigidbody>().AddForce(Vector3.up * force, ForceMode.Impulse);
            }
            // Debug.Log("Jump Boots");
            // player.GetComponent<Rigidbody>().AddForce(Vector3.up * force, ForceMode.Impulse);
        }
    }

    public void Spinning(GameObject player, float torque)
    {
        if (spinEffect)
        {
            Debug.Log("Spinning Effect");
            player.GetComponent<Rigidbody>().AddTorque(transform.right * torque);
        }
    }

    public void SpeedBoots(GameObject player, float speed)
    {
        if (speedEffect)
        {
            Debug.Log("Speed Boots");
            player.GetComponent<Rigidbody>().AddForce(Vector3.back * speed, ForceMode.Impulse);
        }
    }
    
    public void Slow(GameObject player, float force)
    {
        if (slowEffect)
        {
            Debug.Log("Turn Back");
            player.GetComponent<Rigidbody>().AddForce(Vector3.forward * force, ForceMode.Impulse);
        }
    }

    #endregion

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            JumpBoots(collision.gameObject, jumpPadForce);
            SpeedBoots(collision.gameObject, speedBoots);
            Spinning(collision.gameObject, spinTorque);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("is Trigger");
            SpeedBoots(other.gameObject, speedBoots);
            Slow(other.gameObject, turnBackForce);
            JumpBoots(other.gameObject, jumpPadForce);
        }
    }
}
