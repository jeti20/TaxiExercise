using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxiGameManager: MonoBehaviour
{
    #region SINGLETON
    private static TaxiGameManager _instance;

    public static TaxiGameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<TaxiGameManager>();
            }
            return _instance;
        }
    }
    #endregion

    public GameObject passengerPrefab;
    public GameObject destinationPrefab; 

    public Transform[] passengerSpawnPoints; // passanger pawn point
    public Transform[] destinationSpawnPoints; // destination poi

    private GameObject currentPassenger; 
    private GameObject currentDestination; 

    //private bool hasPassenger; 

    
    void Start()
    {
        SpawnPassenger();
    }

    
    void SpawnPassenger()
    {
        // losowanie random point of passenger
        int passengerSpawnIndex = Random.Range(0, passengerSpawnPoints.Length);
        Transform passengerSpawnPoint = passengerSpawnPoints[passengerSpawnIndex];

        // spawning passengerPrefab on Random passenger spawn point
        currentPassenger = Instantiate(passengerPrefab, passengerSpawnPoint.position, Quaternion.identity);
        //hasPassenger = false; 
    }

    //Spawning Destination after taking passenger
    void SpawnDestination()
    {
        //losowanie random point of desination
        int destinationSpawnIndex = Random.Range(0, destinationSpawnPoints.Length);
        Transform destinationSpawnPoint = destinationSpawnPoints[destinationSpawnIndex];

        //spawning DestinationPrefab on Random Destination spawn point
        currentDestination = Instantiate(destinationPrefab, destinationSpawnPoint.position, Quaternion.identity);
    }

    //Taking passenger
    public void OnPlayerTakePassenger()
    {
        Destroy(currentPassenger);
        SpawnDestination();
        //hasPassenger = true; 
        Debug.Log("Wziêcie pasa¿era i spawowanie destynacji");
    }

    //Taking Destination 
    public void OnPlayerDeliverPassenger()
    {
        Destroy(currentDestination);
        SpawnPassenger();
        Debug.Log("odwiezienie i spawnowanie nowego pasazera");
        //hasPassenger = false; 
    }
}
