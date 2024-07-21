using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public event Action<bool> onPlayerIdleChange;

    [Header("Setup")]
    [SerializeField] private float speedPc;
    [SerializeField] private float speedMovile;
    [SerializeField] private string starTag;

    private float currenSpeed = 0;
    private float correctPlayerSpeed = -0.8f;

    private Vector3 mousePos;

    private Rigidbody2D rb;


    [Header("References")]
    [SerializeField] private PlayerJump jump;
    [SerializeField] private StarsCounterManager starsCounterManager;
    [SerializeField] private ButtonData buttonData;

    private InterfaceCommand moveCommand;

    private void Start()
    {
        CheckSpeed();
        rb = GetComponent<Rigidbody2D>();
        moveCommand = new MoveCommand(this);
    }

    public void CheckMousePos() 
    {
        mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
    }

    public void StartMoveTouch() 
    {
        if (mousePos.x > 0.5)
        {
            rb.AddForce(new Vector2(currenSpeed, 0), ForceMode2D.Force);
        }

        if (mousePos.x < 0.5)
        {
            rb.AddForce(new Vector2(-currenSpeed, 0), ForceMode2D.Force);
        }
    }

    public void CorrectPlayerSpeed() 
    {
        if(jump.isGrounded)
        {
            onPlayerIdleChange?.Invoke(true);
            currenSpeed = 0;
            rb.AddForce(new Vector2(correctPlayerSpeed, 0), ForceMode2D.Force);
        }

        else 
        {
            CheckSpeed();
            onPlayerIdleChange?.Invoke(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(starTag)) 
        {
            FindObjectOfType<AudioManager>().Play("PickUp");
            Destroy(collision.gameObject);
            MultiplyStars();
        }
    }

    private void MultiplyStars() 
    {
        if (buttonData.LoadInfo("X2"))
        {
            starsCounterManager.AddStars(2);
        }

        if (!buttonData.LoadInfo("X2")) 
        {
            starsCounterManager.AddStars(1);
        }
    }

    public void CheckSpeed() 
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            currenSpeed = speedPc; 
        }

        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            currenSpeed = speedMovile;
        }
    }

    public void ExecutePlayerMoveCommand() 
    {
        moveCommand.Execute();
    }
}
