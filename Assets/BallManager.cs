using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;  // Set bola sebagai kinematic pada awalnya
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Mengubah menjadi tidak kinematic saat bola pertama kali terkena sentuhan
        if (rb.isKinematic)
        {
            rb.isKinematic = false;  // Matikan kinematic agar bola mulai bergerak

            // Optional: Tambahkan gaya acak untuk memulai gerakan
            Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
            rb.AddForce(randomDirection.normalized * 300f);  // Sesuaikan kekuatan sesuai kebutuhan
        }
    }
}
