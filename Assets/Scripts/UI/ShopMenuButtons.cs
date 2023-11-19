using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopMenuButtons : MonoBehaviour
{
    [SerializeField] private string[] sceneName;
    [SerializeField] private GameObject shop;
    [SerializeField] private GameObject popUp;
    [SerializeField] private PopUpManager popUpManager;
    [SerializeField] private Image[] skinImage;

    [SerializeField] private TextMeshProUGUI priceText;
    private string priceTextValue = "5";

    private void Start()
    {
        priceText.text = priceTextValue;
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene(sceneName[0]);
    }

    public void ShowPinkManSkin() 
    {
        popUpManager.SetSkinImage(skinImage[0]);
        popUpManager.SetPriceText(priceText);
        shop.SetActive(false);
        popUp.SetActive(true);
    }

    public void ShowNinjaFrogSkin() 
    {
        popUpManager.SetSkinImage(skinImage[1]);
        popUpManager.SetPriceText(priceText);
        shop.SetActive(false);
        popUp.SetActive(true);
    }

    public void ShowMaskDudeSkin() 
    {
        popUpManager.SetSkinImage(skinImage[2]);
        popUpManager.SetPriceText(priceText);
        shop.SetActive(false);
        popUp.SetActive(true);
    }

    public void PopUpBuy() 
    {
        popUp.SetActive(false);
        shop.SetActive(true);
    }
}
