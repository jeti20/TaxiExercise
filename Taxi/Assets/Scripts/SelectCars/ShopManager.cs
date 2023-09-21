using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    public int currentCarIndex;
    public GameObject[] carModels;

    [SerializeField] private AudioSource chaneCarSound;

    private void Start()
    {
        currentCarIndex = PlayerPrefs.GetInt("SelectedCar", 0);

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
        PlayerPrefs.SetInt("SelectedCar", currentCarIndex);
        chaneCarSound.Play();
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
        PlayerPrefs.SetInt("SelectedCar", currentCarIndex);
        chaneCarSound.Play();
    }


    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

}
