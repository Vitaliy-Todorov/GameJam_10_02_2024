using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewItem", menuName = "ScriptableObject/Item")]
public class Item : ScriptableObject
{
    public string title; //�������� �������� ��� ����������� ����
    [TextArea] public string message; //��������� ��� ������

    public Image uiImage; //���� ����� �������� �������� �� UI
}
