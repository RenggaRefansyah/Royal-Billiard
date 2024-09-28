using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float forceAmount = 500f;  // Kekuatan dorongan (sodokan)
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Ambil referensi Rigidbody bola putih
        rb.isKinematic = false;  // Bola putih tidak kinematic agar bisa bergerak
    }

    void Update()
    {
        // Jika tombol Space ditekan
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Tambahkan gaya ke arah sumbu X bola putih
            rb.AddForce(Vector3.left * forceAmount);
        }

        // Hentikan bola jika sangat lambat
        if (rb.velocity.magnitude < 0.1f)
        {
            rb.velocity = Vector3.zero;
        }
    }
}
