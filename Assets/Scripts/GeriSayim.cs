using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeriSayim : MonoBehaviour
{
    float toplamSure = 0;
    float gecenSure = 0;

    bool calisiyor = false;
    bool basladi = false;
    
    //Geri sayým sayacýnýn toplam süresini ayarlar
    public float ToplamSure
    {
        set //deðer atamak       get --> deðer okumak
        {//sayaç çalýþýrken deðiþim yapýlmamalý
            if (!calisiyor)
            {
                toplamSure = value;
                //bu prop dýþarýdan çaðrýlýrken bir deðerle çaðrýlýyorsa 
                // bu deðeri içeride value ile okuyoruz
            }
        }
    }
    //Toplam sürenin bitip bitmediði 
    public bool Bitti
    {
        get
        {
            return basladi && !calisiyor;
        }
    }
    
    //Sayacý çalýþtýrýr
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
        //update her framede çaðrýlýr  
        if (calisiyor)
        {
            gecenSure += Time.deltaTime; //deltaTime sistem çalýþtýktan sonraki süreyi hesaplar ve birimi fps
            if (gecenSure >= toplamSure)
            {
                calisiyor = false;
            }
        }
    }
}
