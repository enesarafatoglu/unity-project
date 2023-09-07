using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YokEdici : MonoBehaviour
{
    [SerializeField]
    GameObject patlamaPrefab;
    GeriSayim yokEdiciGeriSayim;

    // Start is called before the first frame update
    void Start()
    {
        yokEdiciGeriSayim = gameObject.AddComponent<GeriSayim>();
        yokEdiciGeriSayim.ToplamSure = Random.Range(1, 20);
        yokEdiciGeriSayim.Calistir();
    }

    // Update is called once per frame
    void Update()
    {
        if (yokEdiciGeriSayim.Bitti)
        {//qua -> patlamanýn rotasyonunda herhangi bir deðiþiklik istemiyoruz
            Instantiate(patlamaPrefab, gameObject.transform.position,Quaternion.identity); //patlama prefabini var etme
            Destroy(gameObject);  //objeyi yok etme
        }
    }
}
