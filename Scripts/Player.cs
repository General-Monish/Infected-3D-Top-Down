using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player instance { get; private set; }

    private Vector3 MousePosition;
    private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;
    [SerializeField] private float _speed = 10f;
    [SerializeField]
    private float _rotationSpeed = 900f;
    private Animator anim;
    // Start is called before the first frame update

    private void Awake()
    {

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        MousePosition = transform.position;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MouseMovement();
        SetPlayerVelocity();
        RotateInDirectionOfInput();
    }
    private void MouseMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("walk", true);
            // Update target position on  left-click
            MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            MousePosition.z = transform.position.z;

            // Set movement input based on the new target position
            _movementInput = (MousePosition - transform.position).normalized;

          /*  // Set the target position directly
            MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            MousePosition.z = transform.position.z;*/
        }
        // Check if the player is close to the target position, and reset movement input
        if (Vector2.Distance(transform.position, MousePosition) < 1f)
        {
            _movementInput = Vector2.zero;
            anim.SetBool("walk", false);
        }

    }

    private void SetPlayerVelocity()
    {
        _smoothedMovementInput = Vector2.SmoothDamp(_smoothedMovementInput, _movementInput, ref _movementInputSmoothVelocity, 0.1f);

        _rigidbody.velocity = _smoothedMovementInput * _speed;
    }

    private void RotateInDirectionOfInput()
    {
        if (_movementInput != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _smoothedMovementInput);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

            _rigidbody.MoveRotation(rotation);
        }
    }
}




