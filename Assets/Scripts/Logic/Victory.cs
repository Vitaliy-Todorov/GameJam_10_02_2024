using UnityEngine;

public class Victory : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverMenu;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            _gameOverMenu.SetActive(true);
        }
    }
}