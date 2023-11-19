using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopMenuButtons : MonoBehaviour
{
    [Header("Shop References")]
    [SerializeField] private string[] sceneName;
    [SerializeField] private PopUpManager popUpManager;
    [SerializeField] private Image[] skinImage;
    [SerializeField] private GameObject shop;
    [SerializeField] private GameObject popUp;
    [SerializeField] private GameObject menuButton;

    [Header("PowerUps texts")]
    [SerializeField] private GameObject X2Text;
    [SerializeField] private GameObject plus50MText;

    [Header("PriceText")]
    [SerializeField] private TextMeshProUGUI priceText;
    private string priceSkinTextValue = "5";
    private string pricePowerUpTextValue = "10";
    public void ReturnMenu()
    {
        SceneManager.LoadScene(sceneName[0]);
    }

    public void ShowPinkManSkin() 
    {
        priceText.text = priceSkinTextValue;
        popUpManager.SetSkinImage(skinImage[0]);
        popUpManager.SetPriceText(priceText);
        X2Text.SetActive(false);
        plus50MText.SetActive(false);
        menuButton.SetActive(false);
        shop.SetActive(false);
        popUp.SetActive(true);
    }

    public void ShowNinjaFrogSkin() 
    {
        priceText.text = priceSkinTextValue;
        popUpManager.SetSkinImage(skinImage[1]);
        popUpManager.SetPriceText(priceText);
        X2Text.SetActive(false);
        plus50MText.SetActive(false);
        menuButton.SetActive(false);
        shop.SetActive(false);
        popUp.SetActive(true);
    }

    public void ShowMaskDudeSkin() 
    {
        priceText.text = priceSkinTextValue;
        popUpManager.SetSkinImage(skinImage[2]);
        popUpManager.SetPriceText(priceText);
        X2Text.SetActive(false);
        plus50MText.SetActive(false);
        menuButton.SetActive(false);
        shop.SetActive(false);
        popUp.SetActive(true);
    }

    public void ShowX2PowerUp() 
    {
        popUpManager.CheckPowerUp();
        priceText.text = pricePowerUpTextValue;
        X2Text.SetActive(true);
        plus50MText.SetActive(false);
        menuButton.SetActive(false);
        shop.SetActive(false);
        popUp.SetActive(true);
    }

    public void ShowPlusMetersPowerUp() 
    {
        popUpManager.CheckPowerUp();
        priceText.text = pricePowerUpTextValue;
        X2Text.SetActive(false);
        plus50MText.SetActive(true);
        menuButton.SetActive(false);
        shop.SetActive(false);
        popUp.SetActive(true);
    }

    public void PopUpBuy() 
    {
        popUp.SetActive(false);
        menuButton.SetActive(true);
        shop.SetActive(true);
    }

    public void PopUpExit() 
    {
        popUp.SetActive(false);
        menuButton.SetActive(true);
        shop.SetActive(true);
    }
}
