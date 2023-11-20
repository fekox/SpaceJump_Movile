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

    private void Start()
    {
        gameManger.pauseGame = true;
        DisableSkins();
    }

    private void DisableSkins() 
    {
        for (int i = 0; i < playerSkins.Length; i++) 
        {
            playerSkins[i].SetActive(false);
        }
    }
    public void SelectVirtualBoySkin() 
    {
        playerSkins[0].SetActive(true);
        selectCharacterPopup.SetActive(false);
        tutorialPopup.SetActive(true);
        gameManger.selecCharacter = true;
    }

    public void SelectPinkManSkin() 
    {
        playerSkins[1].SetActive(true);
        selectCharacterPopup.SetActive(false);
        tutorialPopup.SetActive(true);
        gameManger.selecCharacter = true;
    }

    public void SelectNinjaFrogSkin() 
    {
        playerSkins[2].SetActive(true);
        selectCharacterPopup.SetActive(false);
        tutorialPopup.SetActive(true);
        gameManger.selecCharacter = true;
    }

    public void SelectMaskDudeSkin() 
    {
        playerSkins[3].SetActive(true);
        selectCharacterPopup.SetActive(false);
        tutorialPopup.SetActive(true);
        gameManger.selecCharacter = true;
    }
}
