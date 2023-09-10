using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameTrigger : MonoBehaviour
{
    private bool playerInsideTrigger = false; // Czy gracz jest wewn�trz triggara?
    private float insideTriggerTime = 0f; // Czas, przez kt�ry gracz jest wewn�trz triggara

    private void Update()
    {
        // Je�li gracz jest wewn�trz triggara, zwi�ksz czas
        if (playerInsideTrigger)
        {
            insideTriggerTime += Time.deltaTime;

            // Je�li gracz pozosta� w triggare przez 1 sekund�, mo�esz uruchomi� gr� lub inne dzia�ania
            if (insideTriggerTime >= 1f)
            {
                // Tutaj mo�esz uruchomi� gr� lub inne dzia�ania
                StartGame(); // Przyk�adowa metoda rozpoczynaj�ca gr�
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Sprawd�, czy gracz wjecha� w trigger
        if (other.CompareTag("Player"))
        {
            playerInsideTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Gracz opu�ci� trigger, zresetuj zmienne
        if (other.CompareTag("Player"))
        {
            playerInsideTrigger = false;
            insideTriggerTime = 0f;
        }
    }

    // Przyk�adowa metoda rozpoczynaj�ca gr�
    private void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}