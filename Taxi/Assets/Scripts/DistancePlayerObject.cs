using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistancePlayerObject : MonoBehaviour
{
    #region SINGLETON
    private static DistancePlayerObject _instance;

    public static DistancePlayerObject Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<DistancePlayerObject>();
            }
            return _instance;
        }
    }
    #endregion

    public string playerTag = "Player"; // Tag gracza
    public string destinationTag = "Destination"; // Tag punktu docelowego
    public string passengerTag = "Passenger"; // Tag pasa�era

    private Transform playerTransform; // Transform gracza


    private void Start()
    {
        StartCoroutine(Delay());      
    }

    private void FindingPlayer()
    {
        // Znajd� gracza na scenie na podstawie tagu
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);

        if (playerObject != null)
        {
            // Pobierz transform gracza
            playerTransform = playerObject.transform;
        }
        else
        {
            Debug.LogError("Nie znaleziono obiektu gracza o tagu: " + playerTag);
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1);
        FindingPlayer();
    }

    public float distance;

    public void Measure()
    {
        if (playerTransform != null)
        {
            // Znajd� wszystkie obiekty o tagu "Destination"
            GameObject[] destinationObjects = GameObject.FindGameObjectsWithTag(destinationTag);

            foreach (GameObject destinationObject in destinationObjects)
            {
                // Oblicz odleg�o�� mi�dzy graczem a punktem docelowym
                float distanceToDestination = Vector3.Distance(playerTransform.position, destinationObject.transform.position);
                distance = distanceToDestination;
                Debug.Log("Odleg�o�� do punktu docelowego: " + distanceToDestination);
            }

            /*// Znajd� wszystkie obiekty o tagu "Passenger"
            GameObject[] passengerObjects = GameObject.FindGameObjectsWithTag(passengerTag);

            foreach (GameObject passengerObject in passengerObjects)
            {
                // Oblicz odleg�o�� mi�dzy graczem a pasa�erem
                float distanceToPassenger = Vector3.Distance(playerTransform.position, passengerObject.transform.position);
                Debug.Log("Odleg�o�� do pasa�era: " + distanceToPassenger);
            }*/
        }
    }
}
