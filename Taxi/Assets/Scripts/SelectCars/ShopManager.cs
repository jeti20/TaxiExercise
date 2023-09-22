using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ShopManager : MonoBehaviour
{
    public int currentCarIndex;
    public GameObject[] carModels;
    public CarBlueprint[] cars;
    public Button buyButton;


    [SerializeField] private AudioSource chaneCarSound;

    private void Update()
    {
        UpdateUI();
    }

    private void Start()
    {
        Debug.Log(PlayerPrefs.GetFloat("GlobalDollars", 0));
        foreach (CarBlueprint car in cars)
        {
            if (car.price == 0)
            {
                car.isUnlocked = true;
            }
            else
            {
                //car.isUnlocked = PlayerPrefs.GetInt(car.name, 0) == 0 ? false: true;
                if (PlayerPrefs.GetInt(car.name, 0) == 0)
                {
                    car.isUnlocked = false;
                }
                else
                {
                    car.isUnlocked = true;
                }
            }
        }


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
        CarBlueprint c = cars[currentCarIndex];
        if (!c.isUnlocked)
        {
            return;
        }
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
        CarBlueprint c = cars[currentCarIndex];
        //checking
        if (!c.isUnlocked) 
        {
            return;
        }
        chaneCarSound.Play();
    }


    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }


    private void UpdateUI()
    {
        CarBlueprint c = cars[currentCarIndex];

        if (c.isUnlocked)
        {
            buyButton.gameObject.SetActive(false);
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Buy " + c.price + "$";
            
            if (c.price < PlayerPrefs.GetInt("GlobalDollars", 0))
            {
                
                buyButton.interactable = false;
            }
            else
            {
                //Debug.Log(TaxiGameManager.Instance.allDollars);
                buyButton.interactable = true;
            }
        }       
    }

    public void UnlockCar()
    {
        CarBlueprint c = cars[currentCarIndex];
        PlayerPrefs.SetInt(c.name, 1);
        PlayerPrefs.SetInt("SelectedCar", currentCarIndex);
        c.isUnlocked = true;
        PlayerPrefs.SetFloat("GlobalDollars", PlayerPrefs.GetFloat("GlobalDollars", 0) - c.price);
    }
}
