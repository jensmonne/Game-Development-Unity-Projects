using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject loot;

    private SpriteRenderer spriteRenderer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OpenChest();
        }
    }

    void OpenChest()
    {
        if (loot != null)
        {
            Instantiate(loot, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}