using System;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeReference]
    private IBehaviorNode _rootNode = new Vision();
    [SerializeReference]
    private IBehaviorNode _currentNode;

    private void Awake()
    {
        _currentNode = _rootNode;
        while (_currentNode != null)
        {
            _currentNode.Awake();
            _currentNode = _currentNode.NextNod;
        }

        _currentNode = _rootNode;
    }

    private void Update()
    {
        _currentNode = _rootNode;
        while (_currentNode != null)
        {
            if(_currentNode.Condition()) 
                _currentNode.Action();
            _currentNode = _currentNode.NextNod;
        }

        _currentNode = _rootNode;
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        _currentNode = _rootNode;
        while (_currentNode != null)
        {
            if(_currentNode is Vision vision)
                vision.OnTriggerEnter2D(col);
            _currentNode = _currentNode.NextNod;
        }

        _currentNode = _rootNode;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _currentNode = _rootNode;
        while (_currentNode != null)
        {
            if(_currentNode is Vision vision)
                vision.OnTriggerExit2D(other);
            _currentNode = _currentNode.NextNod;
        }

        _currentNode = _rootNode;
    }
}