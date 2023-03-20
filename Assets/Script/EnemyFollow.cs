using System;
using UnityEngine;

public class EnemyFollow : MonoBehaviour

{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 locationOffset;
    public Vector3 rotationOffset;

    private void Start()
    {
        target = FindObjectOfType<LogControl>().gameObject.transform;
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + target.rotation * locationOffset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}