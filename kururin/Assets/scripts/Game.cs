using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{

    [SerializeField] private int health = 3;

    [SerializeField] private int currentLevel;
    
    public bool hSignalActive;
    
    public bool fSignalActive;
    
    void Start()
    {
        currentLevel = PlayerPrefs.GetInt("currentLevel", 0);
    }

    void Update()
    {
        if (hSignalActive)
        {
            health -= 1;
            hSignalActive = false;
        }
        
        if (health <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        if (fSignalActive)
        {
            currentLevel += 1;
            fSignalActive = false;
            PlayerPrefs.SetInt("currentLevel", currentLevel);
            PlayerPrefs.Save();
            if (currentLevel == 1)
            {
                SceneManager.LoadScene("Level_2");
            }
            else if (currentLevel == 2)
            {
                SceneManager.LoadScene("WinScreen");
            }
        }
    }
}
