using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private bool isGround = false;

    private void OnCollisionStay(Collision col)
    {
        if (col.gameObject.CompareTag("ground"))
        {
            isGround = true;
        }
       
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("ground"))
        {
            isGround = false;
        }
    }

    public bool GetIsGround()
    {
        return isGround;
    }
}
