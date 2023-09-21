using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    public int currentCarIndex;
    public GameObject[] carModels;

    private void Start()
    {
        currentCarIndex = PlayerPrefs.GetInt("SeleectedCar", 0);

        foreach (GameObject car in carModels)
        {
            car.SetActive(false);

            carModels[currentCarIndex].SetActive(true);
        }
    }

    public void ChangeNext()
    {
        carModels[currentCarIndex].SetActive(false);

        currentCarIndex++;
        if (currentCarIndex == carModels.Length)
        {
            currentCarIndex = 0;
        }

        carModels[currentCarIndex].SetActive(true);
        currentCarIndex = PlayerPrefs.GetInt("SeleectedCar", currentCarIndex);
    }

    public void ChangePrevious()
    {
        carModels[currentCarIndex].SetActive(false);

        currentCarIndex--;
        if (currentCarIndex == -1)
        {
            currentCarIndex = carModels.Length-1;
        }

        carModels[currentCarIndex].SetActive(true);
        currentCarIndex = PlayerPrefs.GetInt("SeleectedCar", currentCarIndex);
    }


    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

}
