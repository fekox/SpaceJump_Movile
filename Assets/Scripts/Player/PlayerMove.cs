using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public event Action<bool> onPlayerIdleChange;

    [Header("Setup")]
    [SerializeField] private float speed;

    private float currenSpeed = 0;

    private Vector3 mousePos;

    private Rigidbody2D rb;

    [Header("References")]
    [SerializeField] private PlayerJump jump;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currenSpeed = speed; 
    }

    public void CheckMousePos() 
    {
        mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
    }

    public void StartMoveTouch() 
    {
        if (mousePos.x > 0.5)
        {
            rb.AddForce(new Vector2(speed, 0), ForceMode2D.Force);
        }

        if (mousePos.x < 0.5)
        {
            rb.AddForce(new Vector2(-speed, 0), ForceMode2D.Force);
        }
    }

    public void CorrectPlayerSpeed() 
    {
        if(jump.isGrounded)
        {
            onPlayerIdleChange?.Invoke(true);
            speed = 0;
            rb.AddForce(new Vector2(-0.8f, 0), ForceMode2D.Force);
        }

        else 
        {
            speed = currenSpeed;
            onPlayerIdleChange?.Invoke(false);
        }
    }
}
