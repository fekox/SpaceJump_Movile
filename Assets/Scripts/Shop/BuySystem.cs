using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuySystem : MonoBehaviour
{
    [SerializeField] private ButtonData buttonData;

    public void BuyPinkMan() 
    {
        buttonData.isPinkManBuyed = true;
        buttonData.SaveInfo("PinkMan", buttonData.isPinkManBuyed);
    }
    
    public void BuyNinjaFrog() 
    {
        buttonData.isNinjaFrogBuyed = true;
        buttonData.SaveInfo("NinjaFrog", buttonData.isNinjaFrogBuyed);
    }

    public void BuyMaskDude() 
    {
        buttonData.isMaskDudeBuyed = true;
        buttonData.SaveInfo("MaskDude", buttonData.isMaskDudeBuyed);
    }

    public void BuyX2PowerUp() 
    {
        buttonData.isX2Buyed = true;
        buttonData.SaveInfo("X2", buttonData.isX2Buyed);
    }

    public void BuyPlusFiftyMeterPowerUp() 
    {
        buttonData.isPlus50MBuyed = true;
        buttonData.SaveInfo("+50M", buttonData.isPlus50MBuyed);
    }
}
