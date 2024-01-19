using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWalkingState : PlayerBaseState
{
    private float speed = 10f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;
    private GameInput gameInput;
   

    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("This is Walking State");
        rb = player.GetComponent<Rigidbody2D>();
        gameInput = player.GetComponent<GameInput>(); // gameinput ki rani

    }

    public override void FixedUpdateState(PlayerStateManager player)
    {
        MovePlayer();
        RotatePlayer();
    }
    public override void OnCollisionEnter(PlayerStateManager player, Collision collision)
    {
        
    }
    public override void UpdateState(PlayerStateManager player)
    {
        if (gameInput != null)
        {
            moveInput = gameInput.GetMovementNormalized();
            moveVelocity = moveInput * speed;
        }
    }
    private void MovePlayer()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
    }
    private void RotatePlayer()
    {
     if (moveInput.magnitude > 0.1f)
       {
        float angle = Mathf.Atan2(moveInput.x, moveInput.y) * Mathf.Rad2Deg;
        Vector3 newRotation = new Vector3(0f, 0f, -angle);
        rb.MoveRotation(Quaternion.Euler(newRotation));
       }
    }
}
