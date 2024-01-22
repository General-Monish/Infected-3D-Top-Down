using System;
using UnityEngine;

public abstract class  PlayerBaseState 
{
    public abstract void EnterState(PlayerStateManager player);
    public abstract void UpdateState(PlayerStateManager player);
    public abstract void FixedUpdateState(PlayerStateManager player);
    public abstract void OnTriggerEnter2D(Collider2D collision);

  
}
