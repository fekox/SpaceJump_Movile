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

    [Header("Ad References")]
    [SerializeField] private GameObject adPopup;
    [SerializeField] private RewardedAdManager rewardedAdManager;

    [Header("Shop System")]
    [SerializeField] private BuySystem buySystem;


    [Header("Button Data")]
    [SerializeField] private ButtonData buttonData;

    [Header("Disable Item")]
    [SerializeField] private DisableIntem[] disableIntems;

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
    private int itemId = 0;

    private void Start()
    {
        CheckItems();
    }
    public void ReturnMenu()
    {
        SceneManager.LoadScene(sceneName[0]);
    }

    public void ShowPinkManSkin() 
    {
        itemId = 1;
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
        itemId = 2;
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
        itemId = 3;
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
        itemId = 4;
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
        itemId = 5;
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
        switch (itemId)
        {
            case 1:
                if (CheckIfCanBuy(priceSkins))
                {
                    starsCounterManager.RemoveStars(priceSkins);
                    buySystem.BuyPinkMan();
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
                if (CheckIfCanBuy(priceSkins))
                {
                    starsCounterManager.RemoveStars(priceSkins);
                    buySystem.BuyNinjaFrog();
                    popUp.SetActive(false);
                    menuButton.SetActive(true);
                    shop.SetActive(true);
                }

                else
                {
                    cantBuyButton.SetActive(true);
                }
            break;

            case 3:
                if (CheckIfCanBuy(priceSkins))
                {
                    starsCounterManager.RemoveStars(priceSkins);
                    buySystem.BuyMaskDude();
                    popUp.SetActive(false);
                    menuButton.SetActive(true);
                    shop.SetActive(true);
                }

                else
                {
                    cantBuyButton.SetActive(true);
                }
            break;

            case 4:
                if (CheckIfCanBuy(pricePowerUp))
                {
                    starsCounterManager.RemoveStars(pricePowerUp);
                    buySystem.BuyX2PowerUp();
                    popUp.SetActive(false);
                    menuButton.SetActive(true);
                    shop.SetActive(true);
                }

                else
                {
                    cantBuyButton.SetActive(true);
                }
            break;

            case 5:
                if (CheckIfCanBuy(pricePowerUp))
                {
                    starsCounterManager.RemoveStars(pricePowerUp);
                    buySystem.BuyPlusFiftyMeterPowerUp();
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

        CheckItems();
    }

    public void CheckItems() 
    {
        if (buttonData.LoadInfo("PinkMan"))
        {
            disableIntems[0].ItemSold();
        }

        if (buttonData.LoadInfo("NinjaFrog"))
        {
            disableIntems[1].ItemSold();
        }

        if (buttonData.LoadInfo("MaskDude"))
        {
            disableIntems[2].ItemSold();
        }

        if (buttonData.LoadInfo("X2"))
        {
            disableIntems[3].ItemSold();
        }

        if (buttonData.LoadInfo("+50M"))
        {
            disableIntems[4].ItemSold();
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

    public void ShowAdsPopup() 
    {
        adPopup.SetActive(true);
    }

    public void HideAdsPopup() 
    {
        adPopup.SetActive(false);
    }

    public void GetRewarded() 
    {
        adPopup.SetActive(false);
        starsCounterManager.starsScore += 15;
        starsCounterManager.SaveStarsScore();
        rewardedAdManager.PlayRewardedAd();
    }
}
