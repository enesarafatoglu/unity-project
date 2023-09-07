using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spcraft : MonoBehaviour
{
    [SerializeField]
    GameObject patlamaPrefab;
    [SerializeField]
    GameObject laser2Prefab;
 
    OyunKontrol oyunKontrol;
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        oyunKontrol = Camera.main.GetComponent<OyunKontrol>();

        float yon = Random.Range(0f, 1.0f);
        if (yon < 0.5)
        {
            rb.AddForce(new Vector2(Random.Range(-2.5f, -1.0f), Random.Range(-2.5f, -1.0f)), ForceMode2D.Impulse);
            rb.AddTorque(yon * 2.0f);
        }
        else
        {
            rb.AddForce(new Vector2(Random.Range(1.0f, 2.5f), Random.Range(-2.5f, -1.0f)), ForceMode2D.Impulse);
            rb.AddTorque(-yon * 2.0f);
        }

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Laser")
        {
            oyunKontrol.SpcYokOldu(gameObject);
            Instantiate(patlamaPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void SpcraftYokEt()
    {
        Instantiate(patlamaPrefab, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private GameObject player;

    private float lastFireTime = 0f;

    [SerializeField] private float fireRate = 1f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (Time.time > lastFireTime + fireRate)
        {
            lastFireTime = Time.time;
            SpawnLaser();
        }
    }

    private void SpawnLaser()
    {
        Vector2 direction = player.transform.position - transform.position;

        direction = direction.normalized;

        GameObject laser = Instantiate(laser2Prefab, transform.position, Quaternion.identity);

        laser.GetComponent<Rigidbody2D>().AddForce(direction * 5f, ForceMode2D.Impulse);
    }
}

    
