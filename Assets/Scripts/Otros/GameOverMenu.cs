using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] PlayerController _player;
    [SerializeField] GameObject _menuGOver;

    void Start()
    {
        _player.Muerte_Player += MenuGameOverOn;
    }

    void MenuGameOverOn()
    {
        Time.timeScale = 0;
        _menuGOver.SetActive(true);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);        
    }

    public void Salir()
    {
        Debug.Log("Salir...");

        Application.Quit();
    }
}
