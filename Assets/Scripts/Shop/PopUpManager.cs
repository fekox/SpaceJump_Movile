using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUpManager : MonoBehaviour
{
    [SerializeField] private Image skinImage;
    [SerializeField] private TextMeshProUGUI priceText;

    public void SetSkinImage(Image newSkinImage) 
    {
        skinImage.sprite = newSkinImage.sprite;
    }

    public void SetPriceText(TextMeshProUGUI newPriceText) 
    {
        priceText.text = newPriceText.text;
    }
}
