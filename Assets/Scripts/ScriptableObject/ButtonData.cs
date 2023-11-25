using System;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "ButtonData", menuName = "Custom/Button Data")]
public class ButtonData: ScriptableObject
{
   public bool isPinkManBuyed = false;
   public bool isNinjaFrogBuyed = false;
   public bool isMaskDudeBuyed = false;

   public bool isX2Buyed = false;
   public bool isPlus50MBuyed = false;

    public void SaveInfo(string keyName, bool isBuyed) 
    {
        int value = isBuyed ? 1 : 0;

        PlayerPrefs.SetInt(keyName, value);
        PlayerPrefs.Save();
    }

    public bool LoadInfo(string keyName) 
    {
        bool isBuyed = false;

        if (PlayerPrefs.HasKey(keyName))
        {
            int loadValue = PlayerPrefs.GetInt(keyName);
            isBuyed = loadValue == 1 ? true : false;

        }

        return isBuyed;
    }
}