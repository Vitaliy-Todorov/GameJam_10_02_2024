using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hand : MonoBehaviour
{
    [SerializeField] private Message _message;
    [SerializeField] private PlayerInput _playerInput;

    private List<ItemHolder> _itemHolders;

    private void Awake()
    {
        _message.gameObject.SetActive(false);
        _itemHolders = new List<ItemHolder>();
        _playerInput.onActionTriggered += OnActionTriggered;
    }

    private void OnActionTriggered(InputAction.CallbackContext context)
    {
        InputAction action = context.action;
        switch (action.name)
        {
            case "Move":
                if (_itemHolders.Count > 0)
                {
                    ShowNearestItemMessage();
                }
                break;
            case "Interaction":
                if (context.performed)
                {
                    Interaction();
                }
                break;
            default:
                break;
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
            _message.Send(nearestHolder.item.title, nearestHolder.item.message);
            _message.gameObject.SetActive(true);
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
            _message.gameObject.SetActive(false);
            _itemHolders.Remove(holder);
        }
    }
}
