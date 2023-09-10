using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPointerController : MonoBehaviour
{
    public float rotationSpeed;

    private GameObject currentPassenger; 
    private GameObject currentDestination; 

    void Update()
    {
        //If there is no currentPassander find one
        if (currentPassenger == null)
        {
            FindNewPassenger();
            //Vector3 direction = (currentPassenger.transform.position - transform.position).normalized;
        }
        //If you passenger is spawned so there is currentPassenger waiting, indicate arrow on him
        if (currentPassenger != null)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(currentPassenger.transform.position - transform.position), rotationSpeed * Time.deltaTime);
        }


        // If there is no destinationpoint in currentdestination find one
        if (currentDestination == null)
        {
            FindNewDestination();
        }
        //If you destinationposint is spawned so there is currentdestination waiting, indicate arrow on it
        if (currentDestination != null)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(currentDestination.transform.position - transform.position), rotationSpeed * Time.deltaTime);
        }
        
    }

    // Finding spawned PassengerObject with proper tag
    private void FindNewPassenger()
    {
        currentPassenger = GameObject.FindGameObjectWithTag("Passenger");
    }

    // Finding spawned DestinationObject with proper tag
    private void FindNewDestination()
    {
        currentDestination = GameObject.FindGameObjectWithTag("Destination");
    }
}

