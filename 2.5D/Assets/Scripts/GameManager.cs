using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int money;

    public bool hpTrigger;

    [SerializeField] private int health;
    
    // private void Start()
    // {
    //     
    // }

    private void Update()
    {
        if (hpTrigger)
        {
            HealthUpdate();
        }
    }

    private void HealthUpdate()
    {
        hpTrigger = false;
        health -= 1;
        
        if (health <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}