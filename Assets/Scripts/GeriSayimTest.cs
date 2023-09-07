using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeriSayimTest : MonoBehaviour
{
    GeriSayim geriSayim;
    float baslangicZamani;

    // Start is called before the first frame update
    void Start()
    {//bu scriptin baðlý olduðu tüm objelere GeriSayim isimli componenti ekleme
       geriSayim = gameObject.AddComponent<GeriSayim>();
       geriSayim.ToplamSure = 3;
       geriSayim.Calistir();

       baslangicZamani = Time.time;//çalýþtýðý andaki zamaný istediðimizden .time kullandýk
    }

    // Update is called once per frame
    void Update()
    {
        if (geriSayim.Bitti)
        {
            float gecenSure = Time.time - baslangicZamani;
            Debug.Log(gecenSure);//geçen süreyi ekrana yazdýrma

            baslangicZamani = Time.time;//tekrar çalýþtýrýlmadan önce þuanki zamana eþitleme
            geriSayim.Calistir(); //sayacý süre bittikten sonra tekrar çalýþtýrma
        }
    }
}
