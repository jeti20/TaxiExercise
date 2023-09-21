using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsSelector : MonoBehaviour
{
    public int currentCarIndex;
    public GameObject[] cars;
    public Transform spawnPoint;

    private GameObject currentCar; // Aktualnie zrespawnowany samoch�d

    private void Start()
    {

        currentCarIndex = PlayerPrefs.GetInt("SeleectedCar", 0);

        Debug.Log(currentCarIndex);
        SpawnCar();
    }

    void SpawnCar()
    {
        // Usuni�cie poprzedniego samochodu, je�li istnieje
        if (currentCar != null)
        {
            Destroy(currentCar);
        }

        // Spawnowanie nowego samochodu na wybranym miejscu
        currentCar = Instantiate(cars[currentCarIndex], spawnPoint.position, Quaternion.identity);
        currentCar.SetActive(true);
    }

}
