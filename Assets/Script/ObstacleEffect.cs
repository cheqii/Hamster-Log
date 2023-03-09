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

    public void JumpBoots(GameObject player, int force)
    {
        if (jumpEffect)
        {
            Debug.Log("Jump Boots");
            player.GetComponent<Rigidbody>().AddForce(Vector3.up * force, ForceMode.Impulse);
        }
        // logControl.RB.AddForce(Vector3.up * 20, ForceMode.Impulse);
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
            player.GetComponent<Rigidbody>().AddForce(Vector3.right * speed, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (this.gameObject.CompareTag("JumpPad"))
            {
                JumpBoots(collision.gameObject, jumpPadForce);
                SpeedBoots(collision.gameObject, speedBoots);
            }
        }
    }
}
