using UnityEngine;


public class ItemHolder : MonoBehaviour
{
    [SerializeField] private GameObject _message;

    public Item item;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController player))
        {
            player.AddHolder(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController player))
        {
            player.RemoveHolder(this);
        }
    }

    public void ShowMessage()
    {
        _message.SetActive(true);
    }

    public void HideMessage()
    {
        _message.SetActive(false);
    }
}
