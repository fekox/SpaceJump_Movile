using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuySystem : MonoBehaviour
{
    [SerializeField] private ButtonData buttonData;

    public void BuyPinkMan() 
    {
        buttonData.isPinkManBuyed = true;
    }
    
    public void BuyNinjaFrog() 
    {
        buttonData.isNinjaFrogBuyed = true;
    }

    public void BuyMaskDude() 
    {
        buttonData.isMaskDudeBuyed = true;
    }

    public void BuyX2PowerUp() 
    {
        buttonData.isX2Buyed = true;
    }

    public void BuyPlusFiftyMeterPowerUp() 
    {
        buttonData.isPlus50Buyed = true;
    }
}
