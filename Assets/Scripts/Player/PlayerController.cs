using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private float _speed;

    private Rigidbody2D _rb;
    private List<ItemHolder> _itemHolders;

    private void Awake()
    {
        _itemHolders = new List<ItemHolder>();
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
            case "Interaction":
                if (context.performed)
                    Interaction();
                break;
        }
    }

    private void Move(Vector2 direction)
    {
        _rb.velocity = direction.normalized * _speed;
        if (_itemHolders.Count > 0)
        {
            ShowNearestItemMessage();
        }
    }

    private ItemHolder SelectNearestHolder()
    {
        if (_itemHolders.Count > 0)
        {
            ItemHolder nearest = _itemHolders[0];
            float distance = Vector2.Distance(nearest.transform.position, transform.position);

            foreach (var holder in _itemHolders)
            {
                float currentDistance = Vector2.Distance(holder.transform.position, transform.position);
                if (distance > currentDistance)
                {
                    nearest = holder;
                    distance = currentDistance;
                }
            }
            return nearest;
        }
        else
        {
            return null;
        }
    }

    private void Interaction()
    {
        ItemHolder nearestHolder = SelectNearestHolder();

        if (nearestHolder != null)
        {
            Debug.Log("ItemMessage: Name=" + nearestHolder.item.title + " message=" + nearestHolder.item.message);
        }
    }

    private void ShowNearestItemMessage()
    {
        ItemHolder nearestHolder = SelectNearestHolder();
        foreach (var holder in _itemHolders)
        {
            holder.HideMessage();
        }
        nearestHolder.ShowMessage();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ItemHolder holder))
        {
            _itemHolders.Add(holder);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ItemHolder holder))
        {
            holder.HideMessage();
            _itemHolders.Remove(holder);
        }
    }
}
