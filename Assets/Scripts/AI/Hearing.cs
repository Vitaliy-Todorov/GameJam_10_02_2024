using System;
using UnityEngine;

[Serializable]
public class Hearing : MoveToGoal
{
    [SerializeField] 
    private PlayerMovement _player;
    
    public override void Awake()
    {
        base.Awake();
        _target = _player.transform;
    }
    
    public override bool Condition() => 
        _player.IsRunning && base.Condition();
}