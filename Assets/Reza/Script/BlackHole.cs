using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
     public float speed = 1f; // Kecepatan peluru
    public Vector2 direction = Vector2.down; // Arah default (horizontal ke kanan)
    private Rigidbody2D rb;
    public bool isDestroyed = false;
    public GameManager gm;

    void Start()
    {
        // Ambil komponen Rigidbody2D
        rb = GetComponent<Rigidbody2D>();

        // Pastikan peluru langsung bergerak di awal
        rb.velocity = direction.normalized * speed;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if(this.transform.localPosition.y < -3.5f){
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }

    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    void OnDestroy()
    {
        gm.gameOver = true;
        
    }

   
}
