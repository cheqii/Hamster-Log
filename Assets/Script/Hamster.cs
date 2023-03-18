using System;
using System.Collections;
using System.Net;
using UnityEngine;

public class Hamster : MonoBehaviour
{
    [SerializeField] private GameObject hamster;
    [SerializeField] private GameObject blood;
    [SerializeField] private LogControl _logControl;
    
    [Header("Magnetic Fields")]
    [SerializeField] private Magnet magnet;
    
    [SerializeField] private CoinSystem coinSystem;

    public void HamsterDie()
    {
        Debug.Log("Hamster is dead");
        coinSystem.TotalCoinCount(); // to counting all coins
        Instantiate(blood, hamster.transform.position, hamster.transform.rotation);
        Destroy(hamster);
        Destroy(_logControl);
        Destroy(_logControl.GetComponent<GroundCheck>());
        Destroy(magnet);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("ground")) HamsterDie();
        
        if(other.gameObject.CompareTag("Obstacle")) HamsterDie();
        
        if(other.gameObject.CompareTag("InvisibleGround")) HamsterDie();
        
        if(other.CompareTag("Magnet"))
        {
            Destroy(other.gameObject);// destroy the magnet
            magnet.Ismagnetic = true;
            StartCoroutine(magnet.MagnetActivate());
        }

        if (other.CompareTag("Coin"))
        {
            Debug.Log("Get Coin");
            Destroy(other.gameObject);
            coinSystem.CoinCollect();
        }
    }
}
