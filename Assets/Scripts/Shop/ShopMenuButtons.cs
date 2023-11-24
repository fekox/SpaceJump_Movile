using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
    [SerializeField] private GameObject cantBuyButton;

    [Header("Stars Counter Manager")]
    [SerializeField] private StarsCounterManager starsCounterManager;

    [Header("PowerUps texts")]
    [SerializeField] private GameObject X2Text;
    [SerializeField] private GameObject plus50MText;

    [Header("PriceText")]
    [SerializeField] private TextMeshProUGUI priceText;
    private string priceSkinTextValue = "5";
    private string pricePowerUpTextValue = "10";
    private int priceSkins = 5;
    private int pricePowerUp = 10;

    [Header("SetUp")]
    private int buttonId = 0;
    public void ReturnMenu()
    {
        SceneManager.LoadScene(sceneName[0]);
    }

    public void ShowPinkManSkin() 
    {
        buttonId = 1;
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
        buttonId = 1;
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
        buttonId = 1;
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
        buttonId = 2;
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
        buttonId = 2;
        popUpManager.CheckPowerUp();
        priceText.text = pricePowerUpTextValue;
        X2Text.SetActive(false);
        plus50MText.SetActive(true);
        menuButton.SetActive(false);
        shop.SetActive(false);
        popUp.SetActive(true);
    }

    public bool CheckIfCanBuy(int price)
    {
        if (starsCounterManager.GetPlayerStarsScore() < price)
        {
            return false;
        }

        if (starsCounterManager.GetPlayerStarsScore() >= price)
        {
            return true;
        }

        return false;
    }

    public void PopUpBuy() 
    {
        switch (buttonId) 
        {
            case 1:

            if (CheckIfCanBuy(priceSkins)) 
            {
                starsCounterManager.RemoveStars(priceSkins);
                popUp.SetActive(false);
                menuButton.SetActive(true);
                shop.SetActive(true);
            }

            else 
            {
                cantBuyButton.SetActive(true);
            }

            break;

            case 2:

            if (CheckIfCanBuy(pricePowerUp)) 
            {
                starsCounterManager.RemoveStars(pricePowerUp);
                popUp.SetActive(false);
                menuButton.SetActive(true);
                shop.SetActive(true);
            }

            else
            {
                cantBuyButton.SetActive(true);
            }

            break;
        }
    }

    public void PopUpExit() 
    {
        popUp.SetActive(false);
        cantBuyButton.SetActive(false);
        menuButton.SetActive(true);
        shop.SetActive(true);
    }

    public void PopUpCantBuyExit()
    {
        cantBuyButton.SetActive(false);
    }
}
