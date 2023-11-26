using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("Jump")]
    [SerializeField] private PlayerJump jump;
    [Header("Move")]
    [SerializeField] private PlayerMove move;

    public void CheckInputs() 
    {
        if (Input.GetMouseButton(0))
        {
            jump.ExecutePlayerjumpCommand();
        }

        if (Input.GetMouseButton(0) && !jump.isGrounded)
        {
            move.ExecutePlayerMoveCommand();
        }
    }
}
