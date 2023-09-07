using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ArayuzKontrol : MonoBehaviour
{
    [SerializeField]
    GameObject oyunAdi;

    [SerializeField]
    GameObject oyunBitti;

    [SerializeField]
    Text puan;

    [SerializeField]
    Text maxPuan;

    [SerializeField]
    GameObject oynaButonu;

    int puanimiz;
    int enYuksekPuan = 0;
    // Start is called before the first frame update
    void Start()
    {
        oyunBitti.gameObject.SetActive(false);
        puan.gameObject.SetActive(true);
        maxPuan.gameObject.SetActive(true);
    }
    public void OyunBasladi()
    {
        puanimiz = 0;
        oyunAdi.gameObject.SetActive(false);
        oynaButonu.gameObject.SetActive(false);
        puan.gameObject.SetActive(true);
        oyunBitti.gameObject.SetActive(false);
        PuaniGuncelle();
    }
    public void OyunBitti()
    {
        oyunBitti.gameObject.SetActive(true);
        oynaButonu.gameObject.SetActive(true);
    }
    void PuaniGuncelle()
    {
        puan.text = "PUAN: " + puanimiz;
        if(puanimiz > enYuksekPuan)
        {
            enYuksekPuan = puanimiz;
        }
        maxPuan.text = "MAX PUAN: " + enYuksekPuan;

    }
    public void SpcYokEdildi()
    {
        puanimiz += 20;
        PuaniGuncelle();
    }
}
