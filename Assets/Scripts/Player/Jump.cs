using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded;

    public float jumpForce;

    public void StartJump() 
    {
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1f, 0.2f), CapsuleDirection2D.Horizontal, 0, groundLayer);

        if (isGrounded) 
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
        }
    }
}
