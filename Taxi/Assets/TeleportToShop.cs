using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToShop : MonoBehaviour
{
    private bool playerInsideTrigger = false;
    private float insideTriggerTime = 0f;
    [SerializeField] string sceneToLoad;

    private void Update()
    {
        // checking if player is in trigger
        if (playerInsideTrigger)
        {
            insideTriggerTime += Time.deltaTime;

            // wait for x seconds before 
            if (insideTriggerTime >= 3f)
            {
                
                LoadShop(); 
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {  
        if (other.CompareTag("Player"))
        {
            playerInsideTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //player left the triger, restart the values for timer
        if (other.CompareTag("Player"))
        {
            playerInsideTrigger = false;
            insideTriggerTime = 0f;
        }
    }

    private void LoadShop()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
