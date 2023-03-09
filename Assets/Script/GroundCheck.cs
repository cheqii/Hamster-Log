using System;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private bool isGround = false;
    private Hamster hamster;

    private void Start()
    {
        hamster = this.transform.Find("Hamster").GetComponent<Hamster>();
    }

    private void OnCollisionStay(Collision col)
    {
        if (col.gameObject.CompareTag("ground"))
        {
            isGround = true;
        }
       if (col.gameObject.CompareTag("InvisibleGround")) hamster.HamsterDie();
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
