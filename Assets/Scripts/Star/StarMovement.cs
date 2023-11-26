using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface InterfacePickUp 
{
    InterfacePickUp Clone();
}

public class StarMovement : Star
{
    [Header("Setup")]
    public string playerTag;

    private void Start()
    {
        starSpeed = 5;
    }

    private void Update()
    {
        StarMove();
    }

    public void StarMove() 
    {
        float speedX = starSpeed * Time.deltaTime;
        transform.position -= new Vector3(speedX, 0f, 0f);
    }

    public override InterfacePickUp Clone()
    {
        return (InterfacePickUp)MemberwiseClone();
    }
}
