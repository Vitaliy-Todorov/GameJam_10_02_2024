using System;
using UnityEngine;

[Serializable]
public class Vision : MoveToGoal
{
    [SerializeField]
    private Transform _transform;
    [SerializeField]
    private float _distance = 3;

    private int _layerPlayer;
    private int _transparentLayers;
    private Vector3 TransformPosition => _agent.transform.position;

    public override void Awake()
    {
        // _nextNod = new Hearing();
        base.Awake();
        _layerPlayer = LayerMask.NameToLayer("Player");
        _transparentLayers = (1 << LayerMask.NameToLayer("Player")) | (1 << LayerMask.NameToLayer("Obstacle"));
    }

    public override bool Condition()
    {
        if(_target == null)
            return false;

        Vector2 direction = (_target.position - TransformPosition).normalized;
        RaycastHit2D hit = Physics2D.Raycast(_transform.position, direction, _distance, _transparentLayers);

        if (hit.collider != null && hit.transform.gameObject.layer == _layerPlayer)
            return base.Condition();
        
        return false;
    }

    public void OnTriggerEnter2D(Collider2D collider) => 
        _target = collider.transform;

    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.transform == _target)
            _target = null;
    }
}