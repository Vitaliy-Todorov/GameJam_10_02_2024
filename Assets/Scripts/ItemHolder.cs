using UnityEngine;


public class ItemHolder : MonoBehaviour
{
    [SerializeField] private GameObject _message;

    public Item item;

    public void ShowMessage()
    {
        _message.SetActive(true);
    }

    public void HideMessage()
    {
        _message.SetActive(false);
    }
}
