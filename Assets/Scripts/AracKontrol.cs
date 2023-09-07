using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AracKontrol : MonoBehaviour
{
    [SerializeField]
    GameObject laserPrefab;
    
    [SerializeField]
    GameObject patlamaPrefab;
    const float hiz = 7;

    OyunKontrol oyunKontrol;
    // Start is called before the first frame update
    void Start()
    {
        oyunKontrol = Camera.main.GetComponent<OyunKontrol>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;//aracýn pozisyonunu kaydetme
        float yatayInput = Input.GetAxis("Horizontal");
        float dikeyInput = Input.GetAxis("Vertical");
        
        if (yatayInput != 0)
        {
            position.x += yatayInput * hiz * Time.deltaTime;
        }
        if (dikeyInput != 0)
        {
            position.y += dikeyInput * hiz * Time.deltaTime;
        }
        transform.position = position;

        if (Input.GetButtonDown("Jump"))
        {
            Vector3 laserKonum = gameObject.transform.position;
            laserKonum.y += 1;
            Instantiate(laserPrefab,laserKonum,Quaternion.identity);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Spcraft")
        {
            oyunKontrol.OyunuBitir();
            Instantiate(patlamaPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    public void OyuncuOldur()
    {
        Instantiate(patlamaPrefab, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
