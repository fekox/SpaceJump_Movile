using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Move")]

    [SerializeField] private float speed;
    [SerializeField] float maxSpeed = 2;
    [SerializeField] private float currentSpeed;

    private Vector3 mousePos;

    private Rigidbody2D rb;

    [Header("Acceleration")]
    [SerializeField] private float acceleration;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = speed;
    }

    public void CheckMousePos() 
    {
        mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
    }

    public void StartMoveTouch() 
    {
        if (mousePos.x > 0.5)
        {
            rb.AddForce(new Vector2(currentSpeed, 0), ForceMode2D.Force);
            CalculeteSpeed();
        }

        if (mousePos.x < 0.5)
        {
            rb.AddForce(new Vector2(-currentSpeed, 0), ForceMode2D.Force);
            CalculeteSpeed();
        }
    }

    private void CalculeteSpeed() 
    {
        if(Mathf.Abs(rb.velocity.y) > 0) 
        {
            currentSpeed += acceleration;
        }

        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
    }

    public void ResetSpeed() 
    {
        currentSpeed = speed;
    }
}
