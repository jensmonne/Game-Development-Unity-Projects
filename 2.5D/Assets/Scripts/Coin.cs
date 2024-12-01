using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameManager gmScript;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gmScript.money += 10;
            Destroy(gameObject);
        }
    }
}