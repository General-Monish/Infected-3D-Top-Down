using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerinputActions;
    public static GameInput Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one instance of gameInput");
        }
        else
        {
            Instance = this;
        }
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
