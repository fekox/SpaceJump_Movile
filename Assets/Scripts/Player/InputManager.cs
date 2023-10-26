using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("Jump")]
    [SerializeField] private Jump jump;

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
           jump.StartJump();
        }
    }
}
