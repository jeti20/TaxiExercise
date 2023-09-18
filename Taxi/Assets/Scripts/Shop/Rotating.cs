using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    public float rotationSpeed = 50.0f; // Pr�dko�� obrotu w stopniach na sekund�.

    void Update()
    {
        // Oblicz k�t obrotu na podstawie pr�dko�ci i czasu od ostatniej klatki.
        float rotationAmount = rotationSpeed * Time.deltaTime;

        // Obr�� cylider wok� jego osi Y (pionowej) o obliczony k�t.
        transform.Rotate(Vector3.up, rotationAmount);
    }
}
