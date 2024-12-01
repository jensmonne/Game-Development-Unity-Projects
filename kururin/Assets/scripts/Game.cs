using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{

    public int health = 3;

    [SerializeField] private int currentLevel;
    
    public bool hSignalActive;
    
    public bool fSignalActive;
    
    private static Game Instance;
    
    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Prevent destruction on scene change
        }
        else
        {
            Destroy(gameObject); // Ensure only one GameManager exists
        }
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
            currentLevel ++;
            fSignalActive = false;
            if (currentLevel == 1)
            {
                SceneManager.LoadScene("Level_2");
            }
            else if (currentLevel == 2)
            {
                currentLevel = 0;
                SceneManager.LoadScene("WinScreen");
            }
        }
    }
}
