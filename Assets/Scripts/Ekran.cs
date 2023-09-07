using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Bu scripti herhangi bir objeye eklemeden sol,sa�,�st,alt de�erlerine her yerden eri�ebilmeliyiz
//Unity oyun objelerine ekli olmayan scriptleri dikkate almad���ndan cagirici scriptini olu�turduk
public static class Ekran
{
    static float sol,sag,ust,alt;
    //ekran�n sol kenar�n�n koodinatlar�n� alma
    public static float Sol
    {
        get
        {
            return sol;
        }
    }

    //ekran�n sa� kenar�n�n koodinatlar�n� alma
    public static float Sag
    {
        get
        {
            return sag;
        }
    }
    //ekran�n �st kenar�n�n koodinatlar�n� alma
    public static float Ust
    {
        get
        {
            return ust;
        }
    }
    //ekran�n alt kenar�n�n koodinatlar�n� alma
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
