using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Bu scripti herhangi bir objeye eklemeden sol,sað,üst,alt deðerlerine her yerden eriþebilmeliyiz
//Unity oyun objelerine ekli olmayan scriptleri dikkate almadýðýndan cagirici scriptini oluþturduk
public static class Ekran
{
    static float sol,sag,ust,alt;
    //ekranýn sol kenarýnýn koodinatlarýný alma
    public static float Sol
    {
        get
        {
            return sol;
        }
    }

    //ekranýn sað kenarýnýn koodinatlarýný alma
    public static float Sag
    {
        get
        {
            return sag;
        }
    }
    //ekranýn üst kenarýnýn koodinatlarýný alma
    public static float Ust
    {
        get
        {
            return ust;
        }
    }
    //ekranýn alt kenarýnýn koodinatlarýný alma
    public static float Alt
    {
        get
        {
            return alt;
        }
    }
    public static void Init()
    {
        float ekranZ = -Camera.main.transform.position.z;
        Vector3 solAltKose = new Vector3(0,0,ekranZ);
        Vector3 sagUstKose = new Vector3(Screen.width,Screen.height,ekranZ);
        Vector3 solAltKoseOyun = Camera.main.ScreenToWorldPoint(solAltKose);
        Vector3 sagUstKoseOyun = Camera.main.ScreenToWorldPoint(sagUstKose);

        sol = solAltKoseOyun.x;
        sag = sagUstKoseOyun.x;
        ust = sagUstKoseOyun.y;
        alt = solAltKoseOyun.y;
    }
}
