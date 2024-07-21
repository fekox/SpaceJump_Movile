using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [Header("Jump")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private float jumpForce;

    public bool isGrounded;

    public float jumpForcePc;
    public float jumpForceMovile;

    public event Action<bool> onPlayerJumpChange;

    private InterfaceCommand jumpCommand;

    private void Start()
    {
        CheckJumpForce();
        jumpCommand = new JumpCommand(this);
    }

    public void StartJump() 
    {
        if (isGrounded == true) 
        {
            FindObjectOfType<AudioManager>().Play("PlayerJump");
            StartCoroutine(PlayerJumpAnimation(1));
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }

    private IEnumerator PlayerJumpAnimation(int time) 
    {
        onPlayerJumpChange?.Invoke(true);
        yield return new WaitForSeconds(time);
        onPlayerJumpChange?.Invoke(false);
    }

    public void CheckIsGrounded() 
    {
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.6f, 0.2f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }

    private void CheckJumpForce() 
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            jumpForce = jumpForcePc;
        }

        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            jumpForce = jumpForceMovile;
        }
    }

    public void ExecutePlayerjumpCommand()
    {
        jumpCommand.Execute();
    }
}
