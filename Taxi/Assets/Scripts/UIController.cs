using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI AllDollars;

    private void Update()
    {
        DollarsManager();
    }

    public void DollarsManager()
    {
        AllDollars.GetComponent<TextMeshProUGUI>().text = "$: " + TaxiGameManager.Instance.allDollars.ToString();       
    }
}
