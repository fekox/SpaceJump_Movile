using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckButtons : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject skinBlack;
    [SerializeField] private Button button;

    public void CheckButton(bool isBuyed) 
    {
        if (isBuyed == true)
        {
            button.enabled = true;
            skinBlack.SetActive(false);
        }

        if (isBuyed == false)
        {
            button.enabled = false;
            skinBlack.SetActive(true);
        }
    }
}
