using System;
using UnityEngine;
using UnityEngine.AI;

public class MoveToGoal : MonoBehaviour
{
    [SerializeField] 
    private Transform _target;
    [SerializeField] 
    private float _agraRadius;
    [SerializeField] 
    private float _maxAgraRadius;

    private bool _agra;
    
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    private void Update()
    {
        if (_target == null)
            return;
        
        Vector2 distanceToTarget = _target.position - transform.position;
        if (!_agra && distanceToTarget.magnitude > _agraRadius)
            return;

        _agra = true;

        if (distanceToTarget.magnitude > _maxAgraRadius)
        {
            _agra = false;
            return;
        }

        _agent.SetDestination(_target.position);
    }
}
