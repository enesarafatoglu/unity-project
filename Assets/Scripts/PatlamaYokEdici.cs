using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatlamaYokEdici : MonoBehaviour
{
    GeriSayim geriSayim;
    // Start is called before the first frame update
    void Start()
    {
        geriSayim = gameObject.AddComponent<GeriSayim>();
        geriSayim.ToplamSure = 1;
        geriSayim.Calistir();
    }

    // Update is called once per frame
    void Update()
    {
        if (geriSayim.Bitti)
        {
            Destroy(gameObject);
        }
    }
}
