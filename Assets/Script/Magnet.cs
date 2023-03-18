using System;
using System.Collections;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [Header("Magnetic Settings")]
    [SerializeField] private bool isMagnetic;

    private Hamster hamster;
    public bool Ismagnetic { get { return isMagnetic; } set { isMagnetic = value; } }

    private void Start()
    {
        hamster = FindObjectOfType<Hamster>().GetComponent<Hamster>();
    }

    public IEnumerator MagnetActivate()
    {
        if (isMagnetic && hamster) this.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(5f);
        isMagnetic = false;
        this.gameObject.SetActive(false);
        
    }
}
