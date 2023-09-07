using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeriSayimTest : MonoBehaviour
{
    GeriSayim geriSayim;
    float baslangicZamani;

    // Start is called before the first frame update
    void Start()
    {//bu scriptin ba�l� oldu�u t�m objelere GeriSayim isimli componenti ekleme
       geriSayim = gameObject.AddComponent<GeriSayim>();
       geriSayim.ToplamSure = 3;
       geriSayim.Calistir();

       baslangicZamani = Time.time;//�al��t��� andaki zaman� istedi�imizden .time kulland�k
    }

    // Update is called once per frame
    void Update()
    {
        if (geriSayim.Bitti)
        {
            float gecenSure = Time.time - baslangicZamani;
            Debug.Log(gecenSure);//ge�en s�reyi ekrana yazd�rma

            baslangicZamani = Time.time;//tekrar �al��t�r�lmadan �nce �uanki zamana e�itleme
            geriSayim.Calistir(); //sayac� s�re bittikten sonra tekrar �al��t�rma
        }
    }
}
