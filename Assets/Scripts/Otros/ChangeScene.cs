using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string nextLevel;

    public void GotoNextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GotoNextScene(nextLevel);
        }
    }

    public void Salir()
    {
        Debug.Log("Salir...");

        Application.Quit();
    }
}
