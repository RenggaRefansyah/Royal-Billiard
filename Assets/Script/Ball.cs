using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;
    public float bounceBall;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;  // Set bola sebagai kinematic pada awalnya
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (rb.isKinematic)
        {
            rb.isKinematic = false;  // Matikan kinematic agar bola mulai bergerak

            // Tambahkan gaya acak dengan kekuatan yang lebih rendah
            Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
            rb.AddForce(randomDirection.normalized * bounceBall);  // Sesuaikan kekuatan sesuai kebutuhan
        }
    }

}
