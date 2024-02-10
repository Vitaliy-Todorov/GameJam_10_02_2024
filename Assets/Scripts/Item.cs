using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewItem", menuName = "ScriptableObject/Item")]
public class Item : ScriptableObject
{
    public string title; //Название предмета для диалогового окна
    [TextArea] public string message; //Сообщение для игрока

    public Image uiImage; //Если будем выводить картинку на UI
}
