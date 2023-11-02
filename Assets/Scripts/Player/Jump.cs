using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [Header("Jump")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public bool isGrounded;

    public float jumpForce;

    public void StartJump() 
    {
        if (isGrounded) 
        {
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }

    public void CheckIsGrounded() 
    {
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1f, 0.2f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }
}
