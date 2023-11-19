using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUpManager : MonoBehaviour
{
    [SerializeField] private Image skinImage;
    [SerializeField] private GameObject skinImageGo;
    [SerializeField] private TextMeshProUGUI priceText;

    public void SetSkinImage(Image newSkinImage) 
    {
        skinImageGo.SetActive(true);
        skinImage.sprite = newSkinImage.sprite;
    }

    public void SetPriceText(TextMeshProUGUI newPriceText) 
    {
        skinImageGo.SetActive(true);
        priceText.text = newPriceText.text;
    }

    public void CheckPowerUp() 
    {
        skinImageGo.SetActive(false);
    }
}
