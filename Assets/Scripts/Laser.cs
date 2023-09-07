using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    GeriSayim geriSayim;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
        geriSayim = gameObject.AddComponent<GeriSayim>();
        geriSayim.ToplamSure = 3;
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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Spcraft")
        {
            Destroy(gameObject);
        }
    }
}
