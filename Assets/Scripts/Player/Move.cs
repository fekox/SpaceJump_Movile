using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [Header("Move")]

    [SerializeField] private float speed;
    [SerializeField] float maxSpeed = 2;
    [SerializeField] private float currentSpeed;

    private Rigidbody2D rb;
    private float moveDirection;

    [Header("Acceleration")]
    [SerializeField] private float acceleration;
    [SerializeField] private float desacceleration;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = speed;
    }

    public void StartMove() 
    {
        moveDirection = Input.GetAxis("Horizontal");
        rb.AddForce(new Vector2(moveDirection * currentSpeed, 0), ForceMode2D.Force);
        CalculeteSpeed();
    }

    private void CalculeteSpeed() 
    {
        if(Mathf.Abs(rb.velocity.y) > 0) 
        {
            currentSpeed += acceleration;
        }

        else 
        {
            currentSpeed -= desacceleration;
        }
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
    }

    public void ResetSpeed() 
    {
        currentSpeed = speed;
    }
}
