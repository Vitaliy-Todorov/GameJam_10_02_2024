using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

[Serializable]
public class MoveToGoal : IBehaviorNode
{
    [SerializeField] 
    protected NavMeshAgent _agent;
    [SerializeField] 
    private float _agraRadius;
    [SerializeField] 
    private float _maxAgraRadius;

    [SerializeReference, Space] 
    protected IBehaviorNode _nextNod;

    protected Transform _target;

    private bool _agra;

    public IBehaviorNode NextNod => _nextNod;

    public virtual void Awake()
    {
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    public virtual bool Condition()
    {
        if (_target == null)
            return false;
        
        Vector2 distanceToTarget = _target.transform.position - _agent.transform.position;
        if (!_agra && distanceToTarget.magnitude > _agraRadius)
            return false;

        _agra = true;

        if (distanceToTarget.magnitude > _maxAgraRadius)
        {
            _agra = false;
            return false;
        }

        return true;
    }

    public virtual void Action() => 
        _agent.SetDestination(_target.transform.position);
}
