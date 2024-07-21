using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacterButtons : MonoBehaviour
{
    [Header("Player Skins")]
    [SerializeField] private GameObject[] playerSkins;
    [SerializeField] private GameObject selectCharacterPopup;

    [Header("Tutorial PopUp")]
    [SerializeField] private GameObject tutorialPopup;

    [Header("Game Manager")]
    [SerializeField] private GameManger gameManger;

    [Header("Check Buttons")]
    [SerializeField] private CheckButtons[] checkButtons;

    [Header("Check Buttons")]
    [SerializeField] private ButtonData buttonData;

    private void Start()
    {
        gameManger.pauseGame = true;
    }

    private void Update()
    {
        SelectCharacterManager();
    }

    public void SelectCharacterManager() 
    {
        if (gameManger.pauseGame == true) 
        {
            checkButtons[0].CheckButton(buttonData.LoadInfo("PinkMan"));
            checkButtons[1].CheckButton(buttonData.LoadInfo("NinjaFrog"));
            checkButtons[2].CheckButton(buttonData.LoadInfo("MaskDude"));
        }
    }

    public void SelectVirtualBoySkin() 
    {
        FindObjectOfType<AudioManager>().Play("Button");
        playerSkins[0].SetActive(true);
        selectCharacterPopup.SetActive(false);
        tutorialPopup.SetActive(true);
        gameManger.selecCharacter = true;
    }

    public void SelectPinkManSkin() 
    {
        FindObjectOfType<AudioManager>().Play("Button");
        playerSkins[1].SetActive(true);
        selectCharacterPopup.SetActive(false);
        tutorialPopup.SetActive(true);
        gameManger.selecCharacter = true;
    }

    public void SelectNinjaFrogSkin() 
    {
        FindObjectOfType<AudioManager>().Play("Button");
        playerSkins[2].SetActive(true);
        selectCharacterPopup.SetActive(false);
        tutorialPopup.SetActive(true);
        gameManger.selecCharacter = true;
    }

    public void SelectMaskDudeSkin() 
    {
        FindObjectOfType<AudioManager>().Play("Button");
        playerSkins[3].SetActive(true);
        selectCharacterPopup.SetActive(false);
        tutorialPopup.SetActive(true);
        gameManger.selecCharacter = true;
    }
}
