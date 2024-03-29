using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameTrigger : MonoBehaviour
{
    private bool playerInsideTrigger = false; 
    private float insideTriggerTime = 0f; 

    private void Update()
    {
        if (playerInsideTrigger)
        {
            insideTriggerTime += Time.deltaTime;


            if (insideTriggerTime >= 1f)
            {
                StartGame(); 
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
        if (other.CompareTag("Player"))
        {
            playerInsideTrigger = false;
            insideTriggerTime = 0f;
        }
    }

    private void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}