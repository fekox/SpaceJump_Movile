using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableSelectCharacterButton : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private ButtonData buttonData;
    [SerializeField] private GameObject skinBlack;
    [SerializeField] private Button button;

    private void Update()
    {
        CheckButton();
    }

    public void CheckButton() 
    {
        if (buttonData.isBuyed == true)
        {
            button.enabled = true;
            skinBlack.SetActive(false);
        }

        if (buttonData.isBuyed == false)
        {
            button.enabled = false;
            skinBlack.SetActive(true);
        }
    }
}
