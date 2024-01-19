using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingWithMouseState : PlayerBaseState
{
    private float speed = 10f;
    private Vector3 target;
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("This is Walking With Mouse State");
        target = player.transform.position;
    }

    public override void FixedUpdateState(PlayerStateManager player)
    {
        
    }

    public override void OnCollisionEnter(PlayerStateManager player, Collision collision)
    {
        
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (Input.GetMouseButtonDown(0)|| Input.GetMouseButtonDown(1))
        {
            // Update target position on right-click And Left Click
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = player.transform.position.z;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.SwitchState(player.walkingState);
            }
        }


        // Move towards the target position
        player.transform.position = Vector3.MoveTowards(player.transform.position, target, speed * Time.deltaTime);
    }
}
