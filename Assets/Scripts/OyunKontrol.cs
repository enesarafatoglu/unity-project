using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class OyunKontrol : MonoBehaviour
{
    [SerializeField]
    GameObject ufoPrefab;
    
    
    [SerializeField]
    List<GameObject> spcraftPrefab = new List<GameObject>();

    GameObject ufo;
    List<GameObject> spcraftList = new List<GameObject>();

    [SerializeField]
    int zorluk = 1;
    [SerializeField]
    int carpan = 3;

    ArayuzKontrol arayuzKontrol;
 
    
    void Start()
    {
        arayuzKontrol = GetComponent<ArayuzKontrol>();
    }

    public void OyunuBaslat()
    {
        arayuzKontrol.OyunBasladi();
        ufo = Instantiate(ufoPrefab);
        ufo.transform.position = new Vector3(0, Ekran.Alt + 2f);
        spcUret(5);
    }

    void spcUret(int adet)
    {
        Vector3 position = new Vector3();
        for (int i = 0; i < adet; i++)
        {
            position.z = -Camera.main.transform.position.z;//objemiz görünmesi için kameranýn önünde olmalý 
            position = Camera.main.ScreenToWorldPoint(position);//position ekranýn piksel deðerlerine göre ayarlandýðýndan oyun dünyasýndaki deðerlere çevirmeliyiz
            position.x = Random.Range(Ekran.Sol, Ekran.Sag);
            position.y = Ekran.Ust - 1;

            GameObject spcraft = Instantiate(spcraftPrefab[Random.Range(0, 3)], position, Quaternion.identity);
            spcraftList.Add(spcraft);
        }
    }

    public void SpcYokOldu(GameObject spcraft)
    {
        arayuzKontrol.SpcYokEdildi();
        spcraftList.Remove(spcraft);
        if (spcraftList.Count <= zorluk)
        {
            zorluk++;
            spcUret(zorluk * carpan);
        }
    }
    public void OyunuBitir()
    {
        foreach (GameObject spcraft in spcraftList)
        {
            spcraft.GetComponent<Spcraft>().SpcraftYokEt();
        }
        spcraftList.Clear();
        zorluk = 1;
        arayuzKontrol.OyunBitti();
    }
    public void OyuncuOldur()
    {
        ufo.GetComponent<AracKontrol>().OyuncuOldur();
        foreach (GameObject spcraft in spcraftList)
        {
            spcraft.GetComponent<Spcraft>().SpcraftYokEt();
        }
        spcraftList.Clear();
        zorluk = 1;
        arayuzKontrol.OyunBitti();
        laser2[] lasers = GameObject.FindObjectsOfType<laser2>();
        foreach (laser2 laser in lasers)
        {
            Destroy(laser.gameObject);
        }
    }
}
