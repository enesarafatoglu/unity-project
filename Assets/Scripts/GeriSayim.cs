using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeriSayim : MonoBehaviour
{
    float toplamSure = 0;
    float gecenSure = 0;

    bool calisiyor = false;
    bool basladi = false;
    
    //Geri say�m sayac�n�n toplam s�resini ayarlar
    public float ToplamSure
    {
        set //de�er atamak       get --> de�er okumak
        {//saya� �al���rken de�i�im yap�lmamal�
            if (!calisiyor)
            {
                toplamSure = value;
                //bu prop d��ar�dan �a�r�l�rken bir de�erle �a�r�l�yorsa 
                // bu de�eri i�eride value ile okuyoruz
            }
        }
    }
    //Toplam s�renin bitip bitmedi�i 
    public bool Bitti
    {
        get
        {
            return basladi && !calisiyor;
        }
    }
    
    //Sayac� �al��t�r�r
    public void Calistir()
    {
        if (toplamSure > 0)
        {
            calisiyor = true;
            basladi = true;
            gecenSure = 0;
        }
    }
    
    void Update()
    {
        //update her framede �a�r�l�r  
        if (calisiyor)
        {
            gecenSure += Time.deltaTime; //deltaTime sistem �al��t�ktan sonraki s�reyi hesaplar ve birimi fps
            if (gecenSure >= toplamSure)
            {
                calisiyor = false;
            }
        }
    }
}
