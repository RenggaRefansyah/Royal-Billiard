using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera camera1; // Kamera utama
    public Camera camera2; // Kamera kedua (di atas meja)

    private void Start()
    {
        // Mulai dengan kamera pertama
        camera1.enabled = true;
        camera2.enabled = false;
    }

    public void SwitchToCamera2()
    {
        camera1.enabled = false;
        camera2.enabled = true;
    }

    public void SwitchToCamera1()
    {
        camera1.enabled = true;
        camera2.enabled = false;
    }
}
