using UnityEngine;
using UnityEngine.SceneManagement;

public class Utility : MonoBehaviour
{
    public void GoToGame()
    {
        SceneManager.LoadScene("Overworld");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}