using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    public float rotationSpeed = 50.0f; // Prêdkoœæ obrotu w stopniach na sekundê.

    void Update()
    {
        // Oblicz k¹t obrotu na podstawie prêdkoœci i czasu od ostatniej klatki.
        float rotationAmount = rotationSpeed * Time.deltaTime;

        // Obróæ cylider wokó³ jego osi Y (pionowej) o obliczony k¹t.
        transform.Rotate(Vector3.up, rotationAmount);
    }
}
