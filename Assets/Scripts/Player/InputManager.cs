using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("Jump")]
    [SerializeField] private PlayerJump jump;
    [Header("Move")]
    [SerializeField] private PlayerMove move;

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
    }
}
