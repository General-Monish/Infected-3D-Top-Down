using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class WalkingWithMouseState : PlayerBaseState
{
   
    private Vector3 MousePosition;
 
    private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;
    private float _speed=10f;

    [SerializeField]
    private float _rotationSpeed=900f;

    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("This is Walking With Mouse State");
        MousePosition = player.transform.position;
        _rigidbody = player.GetComponent<Rigidbody2D>();
    }

    public override void FixedUpdateState(PlayerStateManager player)
    {
        
    }

    public override void OnCollisionEnter(PlayerStateManager player, Collision collision)
    {
        
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            // Update target position on right-click and left-click
            MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            MousePosition.z = player.transform.position.z;

            // Set movement input based on the new target position
            _movementInput = (MousePosition - player.transform.position).normalized;

            // Set the target position directly
            MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            MousePosition.z = player.transform.position.z;
        }

        SetPlayerVelocity();
        RotateInDirectionOfInput(player);

        // Check if the player is close to the target position, and reset movement input
        if (Vector2.Distance(player.transform.position, MousePosition) < 1f)
        {
            _movementInput = Vector2.zero;
        }
    }




    private void SetPlayerVelocity()
    {
        _smoothedMovementInput = Vector2.SmoothDamp(_smoothedMovementInput,_movementInput,ref _movementInputSmoothVelocity,0.1f);

        _rigidbody.velocity = _smoothedMovementInput * _speed;
    }

    private void RotateInDirectionOfInput(PlayerStateManager player)
    {
        if (_movementInput != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(player.transform.forward, _smoothedMovementInput);
            Quaternion rotation = Quaternion.RotateTowards(player.transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

            _rigidbody.MoveRotation(rotation);
        }
    }
}


