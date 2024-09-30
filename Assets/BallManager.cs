using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public GameObject ballPrefab;  // Prefab bola yang akan di-*spawn*
    public Transform pointA;       // Titik pertama dari segitiga
    public Transform pointB;       // Titik kedua dari segitiga
    public Transform pointC;       // Titik ketiga dari segitiga
    public int ballCount = 15;     // Jumlah bola yang akan di-*spawn*
    public float randomFactor = 0.05f;  // Variasi acak untuk posisi bola

    void Start()
    {
        SpawnBallsInTriangle();
    }

    void SpawnBallsInTriangle()
    {
        for (int i = 0; i < ballCount; i++)
        {
            // Dapatkan posisi acak di dalam segitiga
            Vector3 randomPosition = GetRandomPointInTriangle(pointA.position, pointB.position, pointC.position);

            // Tambahkan sedikit variasi acak
            randomPosition.x += Random.Range(-randomFactor, randomFactor);
            randomPosition.z += Random.Range(-randomFactor, randomFactor);

            // Buat bola di posisi yang sudah dihitung
            Instantiate(ballPrefab, randomPosition, Quaternion.identity);
        }
    }

    // Fungsi untuk mendapatkan titik acak dalam segitiga yang dibentuk oleh 3 titik
    Vector3 GetRandomPointInTriangle(Vector3 a, Vector3 b, Vector3 c)
    {
        float r1 = Random.value;
        float r2 = Random.value;

        // Untuk memastikan posisi berada di dalam segitiga
        if (r1 + r2 > 1)
        {
            r1 = 1 - r1;
            r2 = 1 - r2;
        }

        // Hitung posisi di dalam segitiga
        Vector3 randomPoint = (1 - r1 - r2) * a + r1 * b + r2 * c;
        return randomPoint;
    }
}
