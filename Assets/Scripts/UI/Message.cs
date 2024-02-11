using TMPro;
using UnityEngine;

public class Message : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _description;

    public void Send(string title, string description)
    {
        _title.text = title;
        _description.text = description;
    }
}
