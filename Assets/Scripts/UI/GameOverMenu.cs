using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private Button _restart;
    [SerializeField] private Button _exit;
    
    void Start()
    {
        _restart.onClick.AddListener(Restart);
        _exit.onClick.AddListener(Exit);
    }

    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void Restart()
    {
        SceneManager.LoadScene("Vitaliy");
    }

    private void Exit()
    {
        Application.Quit();
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
