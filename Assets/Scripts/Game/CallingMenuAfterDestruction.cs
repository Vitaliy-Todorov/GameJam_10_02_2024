using UnityEngine;

public class CallingMenuAfterDestruction : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverMenu;
    private void OnDestroy()
    {
        if(_gameOverMenu != null)
            _gameOverMenu.SetActive(true);
    }
}