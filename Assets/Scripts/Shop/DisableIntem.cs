using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableIntem : MonoBehaviour
{
    [SerializeField] private GameObject enableItem;
    [SerializeField] private GameObject disableItem;
    [SerializeField] private Button button;

    public void ItemSold()
    {
        button.enabled = false;
        enableItem.SetActive(true);
        disableItem.SetActive(false);
    }
}
