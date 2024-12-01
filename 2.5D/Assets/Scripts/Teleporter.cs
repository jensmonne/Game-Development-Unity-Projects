using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    public int teleporterID;
    public TMP_Text teleportingText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (teleporterID == 1)
            {
                StartCoroutine(HandleTeleporter());
                StartCoroutine(DisplayTeleportTime(3));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        StopAllCoroutines();
        teleportingText.gameObject.SetActive(false);
    }
    
    private IEnumerator HandleTeleporter()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Dungeon_1");
    }

    private IEnumerator DisplayTeleportTime(int countdownTime)
    {
        teleportingText.gameObject.SetActive(true);
        
        while (countdownTime > 0)
        {
            teleportingText.text = "Teleporting in " + countdownTime + "...";
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
        
        teleportingText.text = "Teleporting now...";
    }
}