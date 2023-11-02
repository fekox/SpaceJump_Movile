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
        move.CheckMousePos();
        jump.CheckIsGrounded();

        if (Input.GetMouseButton(0))
        {
            jump.StartJump();
        }

        if (Input.GetMouseButton(0) && !jump.isGrounded)
        {
            move.StartMoveTouch();
        }

        if (jump.isGrounded) 
        {
            move.ResetSpeed();
        }
    }
}
