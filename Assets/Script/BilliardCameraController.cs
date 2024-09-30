using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilliardCameraController : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] Transform cueBall; // Target bola putih
    [SerializeField] float distanceFromCue; // Jarak kamera dari bola
    [SerializeField] Vector3 offset; // Offset untuk mengatur posisi kamera

    void Update()
    {
        // Rotasi kamera berdasarkan input mouse horizontal
        float horizontalInput = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

        // Kamera berputar di sekitar bola putih (hanya di sumbu Y - horizontal)
        transform.RotateAround(cueBall.position, Vector3.up, horizontalInput);

        // Atur posisi kamera berdasarkan jarak dari bola putih
        Vector3 desiredPosition = cueBall.position - transform.forward * distanceFromCue + offset;
        transform.position = desiredPosition;

        // Kamera selalu menghadap bola putih
        transform.LookAt(cueBall.position);
    }
}
