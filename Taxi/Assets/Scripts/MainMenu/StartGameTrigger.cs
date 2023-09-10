using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameTrigger : MonoBehaviour
{
    private bool playerInsideTrigger = false; // Czy gracz jest wewn¹trz triggara?
    private float insideTriggerTime = 0f; // Czas, przez który gracz jest wewn¹trz triggara

    private void Update()
    {
        // Jeœli gracz jest wewn¹trz triggara, zwiêksz czas
        if (playerInsideTrigger)
        {
            insideTriggerTime += Time.deltaTime;

            // Jeœli gracz pozosta³ w triggare przez 1 sekundê, mo¿esz uruchomiæ grê lub inne dzia³ania
            if (insideTriggerTime >= 1f)
            {
                // Tutaj mo¿esz uruchomiæ grê lub inne dzia³ania
                StartGame(); // Przyk³adowa metoda rozpoczynaj¹ca grê
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // SprawdŸ, czy gracz wjecha³ w trigger
        if (other.CompareTag("Player"))
        {
            playerInsideTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Gracz opuœci³ trigger, zresetuj zmienne
        if (other.CompareTag("Player"))
        {
            playerInsideTrigger = false;
            insideTriggerTime = 0f;
        }
    }

    // Przyk³adowa metoda rozpoczynaj¹ca grê
    private void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}