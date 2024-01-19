using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerinputActions;

    private void Awake()
    {
        playerinputActions = new PlayerInputActions();
        playerinputActions.Player.Move.Enable();
        playerinputActions.Player.MouseClick.Enable();
    }

    public Vector2 GetMovementNormalized()
    {
        Vector2 moveInput = playerinputActions.Player.Move.ReadValue<Vector2>();
      
        moveInput = moveInput.normalized;
        return moveInput;
    }
}
