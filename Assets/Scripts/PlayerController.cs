using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Animator _animator;

    [SerializeField] private float _speed;
    [SerializeField] private float _runningSpeed;

    private Rigidbody2D _rb;

    private float _currentSpeed;

    private void Awake()
    {
        _playerInput.onActionTriggered += OnActionTriggered;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnActionTriggered(InputAction.CallbackContext context)
    {
        InputAction action = context.action;
        switch (action.name)
        {
            case "Move":
                Move(action.ReadValue<Vector2>());
                break;
        }
    }

    private void Move(Vector2 direction)
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _currentSpeed = _runningSpeed;
        }
        else
        {
            _currentSpeed = _speed;
        }

        _rb.velocity = direction.normalized * _currentSpeed;

        if (_animator != null)
        {
            WalkAnimation(direction);
        }
    }

    private void WalkAnimation(Vector2 direction)
    {
        if (direction.y > Mathf.Abs(direction.x))
            _animator.Play("Up");
        else if (Mathf.Abs(direction.y) > Mathf.Abs(direction.x))
            _animator.Play("Bottom");
        else if (direction.x > 0)
            _animator.Play("Right");
        else if (direction.x < 0)
            _animator.Play("Left");
        else
            _animator.Play("Stand");
    }

    private void RunningAnimation(Vector2 moveTo) =>
        WalkAnimation(moveTo);
}
