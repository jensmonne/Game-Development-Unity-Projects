using System.Collections;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public GameObject projectile;

    public GameManager gm;

    private bool canTrigger = true;
    
    private bool canShoot = true;

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E))
        if (Input.GetMouseButton(0))
        {
            SpawnProjectile();
        }
    }

    private void SpawnProjectile()
    {
        Vector3 spawnPosition = transform.position;
        
        Quaternion spawnRotation = transform.rotation * Quaternion.Euler(0, 0, 90);

        if (canShoot)
        {
            Instantiate(projectile, spawnPosition, spawnRotation);

            StartCoroutine(HandleProjectileDelay());
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && canTrigger)
        {
            StartCoroutine(HandleCollisionDelay());
        }
    }
    
    private IEnumerator HandleCollisionDelay()
    {
        canTrigger = false;
        gm.hpTrigger = true;
        yield return new WaitForSeconds(0.4f);
        gm.hpTrigger = false;
        canTrigger = true;
    }
    
    private IEnumerator HandleProjectileDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(0.25f);
        canShoot = true;
    }
}