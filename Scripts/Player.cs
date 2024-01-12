using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 smoothMoveInput;
    private Vector2 smoothInputSmoothVelocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        setPlayerVelocity();
        RotateInDireOfInput();
    }

    private void setPlayerVelocity()
    {
        float durationBetweenSmoothAndMoveInput = 0.1f;
        smoothMoveInput = Vector2.SmoothDamp(smoothMoveInput, moveInput, ref smoothInputSmoothVelocity, durationBetweenSmoothAndMoveInput);
        rb.velocity = smoothMoveInput * speed; // smooth movement 
    }
    private void RotateInDireOfInput()
    {
        if (moveInput != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, smoothMoveInput);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            rb.MoveRotation(rotation);
        }
    }

    private void OnMove(InputValue inputValue)
    {
        moveInput = inputValue.Get<Vector2>();
    }
}
