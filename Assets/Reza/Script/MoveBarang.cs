using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBarang : MonoBehaviour
{
    public float speed = 10f; // Kecepatan peluru
    public Vector2 direction = Vector2.right; // Arah default (horizontal ke kanan)

    private Rigidbody2D rb;

    void Start()
    {
        // Ambil komponen Rigidbody2D
        rb = GetComponent<Rigidbody2D>();

        // Pastikan peluru langsung bergerak di awal
        rb.velocity = direction.normalized * speed;
    }

    void Update()
    {
        // (Opsional) Hapus peluru jika terlalu jauh dari layar
        if (Mathf.Abs(transform.position.x) > 50 || Mathf.Abs(transform.position.y) > 50)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Ketika peluru mengenai sesuatu, hancurkan peluru
        Destroy(gameObject);

        // (Opsional) Lakukan sesuatu pada objek yang ditabrak
        Debug.Log($"Peluru mengenai {collision.gameObject.name}");
    }
}
