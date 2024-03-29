using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarChange : MonoBehaviour
{
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;

    [SerializeField] private AudioSource chaneCarSound;

    private void Awake()
    {
        SelectCar(0);
    }

    private int currentCar;

    private void SelectCar(int _index)
    {
        previousButton.interactable = (_index != 0); //turnoff button
        nextButton.interactable = (_index != transform.childCount-1); //turnoff button

        for (int i = 0; i < transform.childCount; i++) 
        {
            transform.GetChild(i).gameObject.SetActive(i == _index);
        }
    }

    public void ChangeCar(int _change)
    {
        currentCar += _change;
        SelectCar(currentCar);

        chaneCarSound.Play();
    }
}
