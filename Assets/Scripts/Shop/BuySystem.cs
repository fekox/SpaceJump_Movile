using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuySystem : MonoBehaviour
{
    [SerializeField] private ButtonData buttonData;
    [SerializeField] private GameObject enableItem;
    [SerializeField] private GameObject disableItem;
    [SerializeField] private Button button;

    public void BuyObject() 
    {
        buttonData.isBuyed = true;
    }

    private void Update()
    {
        if (buttonData.isBuyed == true) 
        {
            DisableItem();
        }

        if (buttonData.isBuyed == false)
        {
            EnableItem();
        }

    }

    public void DisableItem() 
    {
        button.enabled = false;
        enableItem.SetActive(true);
        disableItem.SetActive(false);
    }

    public void EnableItem() 
    {
        button.enabled = true;
        enableItem.SetActive(false);
        disableItem.SetActive(true);
    }
}
