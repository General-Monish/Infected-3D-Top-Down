using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    PlayerBaseState curentState;

   public PlayerIdolState idolState = new PlayerIdolState();
   public PlayerWalkingState walkingState = new PlayerWalkingState();
   public PlayerAttackingState attackingState = new PlayerAttackingState();

    private void Start()
    {
        curentState =walkingState;
        curentState.EnterState(this);
    }
    public void FixedUpdate()
    {
        curentState.FixedUpdateState(this);
    }

    private void Update()
    {
        curentState.UpdateState(this);
    }

    public void SwitchState(PlayerBaseState state)
    {
        curentState=state;
        state.EnterState(this);
    }

}