using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private float _speed;

    private Rigidbody2D _rb;

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
        _rb.velocity = direction.normalized * _speed;
    }
}
