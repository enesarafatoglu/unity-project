using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser2 : MonoBehaviour
{
    OyunKontrol oyunKontrol;
    void Start()
    {
        oyunKontrol = Camera.main.GetComponent<OyunKontrol>();
        Destroy(gameObject, 7f);
    }   
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            oyunKontrol.OyuncuOldur();
            
        }
    }
}
