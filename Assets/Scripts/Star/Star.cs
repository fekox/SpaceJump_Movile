using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour, InterfacePickUp
{
    public float starSpeed;
    public float maxStarPosY = 3f;
    public float minStarPosY = 0f;

    public virtual InterfacePickUp Clone()
    {
        return (InterfacePickUp)MemberwiseClone();
    }
}
