using System;
using System.Collections;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [Header("Magnetic Settings")]
    [SerializeField] private bool isMagnetic;
    public bool Ismagnetic { get { return isMagnetic; } set { isMagnetic = value; } }

    private void Start()
    {
        
    }

    public IEnumerator MagnetActivate()
    {
        if (isMagnetic)
        {
            this.gameObject.SetActive(true);
        }
        
        yield return new WaitForSeconds(5f);
        isMagnetic = false;
        this.gameObject.SetActive(false);
        
    }
}
