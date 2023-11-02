using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("Jump")]
    [SerializeField] private Jump jump;
    [Header("Move")]
    [SerializeField] private Move move;

    void Update()
    {
        jump.CheckIsGrounded();

        if (Input.GetButtonDown("Jump"))
        {
           jump.StartJump();
        }

        if (!jump.isGrounded) 
        {
            move.StartMove();
        }

        if (jump.isGrounded) 
        {
            move.ResetSpeed();
        }
    }
}
