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
    public bool isGrounded;

    public float jumpForce;

    public event Action<bool> onPlayerJumpChange;

    public void StartJump() 
    {
        if (isGrounded == true) 
        {
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
}
