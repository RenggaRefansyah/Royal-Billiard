using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float forceAmount = 500f;  // Kekuatan dorongan (sodokan)
    private Rigidbody rb;
    public CameraSwitcher cameraSwitcher; // Referensi ke CameraSwitcher
    private bool ballIsMoving = false;    // Flag untuk mengecek pergerakan bola
    private bool cameraSwitched = false;  // Flag untuk perpindahan kamera

    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Ambil referensi Rigidbody bola putih
        rb.isKinematic = false;  // Bola putih tidak kinematic agar bisa bergerak
    }

    void Update()
    {
        // Jika bola sudah berhenti, kembali ke kamera 1 setelah 0.5 detik
        if (ballIsMoving && rb.velocity.magnitude < 0.1f)
        {
            rb.velocity = Vector3.zero;  // Hentikan bola sepenuhnya
            ballIsMoving = false;        // Set status bahwa bola sudah berhenti
            cameraSwitched = false;      // Reset flag perpindahan kamera

            // Mulai coroutine untuk penundaan 0.5 detik sebelum kembali ke Kamera 1
            StartCoroutine(SwitchBackToCamera1WithDelay(0.5f));
        }

        // Cek apakah Space ditekan
        if (Input.GetKeyDown(KeyCode.Space) && !ballIsMoving)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Berikan dorongan ke bola
        Vector3 direction = Camera.main.transform.forward; // Arahkan bola ke depan kamera
        rb.AddForce(direction * forceAmount);

        // Tandai bahwa bola mulai bergerak
        ballIsMoving = true;

        // Pindahkan kamera ke kamera 2 langsung saat bola ditembak
        if (!cameraSwitched)
        {
            cameraSwitcher.SwitchToCamera2();
            cameraSwitched = true; // Tandai bahwa kamera telah berpindah
        }
    }

    // Coroutine untuk memberikan jeda sebelum kembali ke kamera 1
    IEnumerator SwitchBackToCamera1WithDelay(float delay)
    {
        // Tunggu selama 'delay' detik
        yield return new WaitForSeconds(delay);

        // Pindah kembali ke kamera 1 setelah penundaan
        cameraSwitcher.SwitchToCamera1();
    }
}
