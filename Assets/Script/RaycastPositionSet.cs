using UnityEngine;

public class RaycastPositionSet : MonoBehaviour
{
    void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, -Vector3.up * 20, out hit))
        {
            if (hit.transform.CompareTag("ground"))
            {
                transform.position = hit.point + (Vector3.up/2);
                
                //Debug.DrawRay(transform.position,-Vector3.up * 20,Color.cyan);
                
               Destroy(GetComponent<RaycastPositionSet>());
            }

        }
    }
}
