using System.Collections;
using UnityEngine;

public class SpawnEffect : MonoBehaviour
{
    public Transform[] fireSpawnPoints; // จุดที่ไฟจะตกลงมาหลายจุด
    public GameObject fireEffectPrefab;
    public float detectionRange = 10f;
    public float fireCooldown = 5f;
    public float fireDelay = 1.5f;
    public float fireDamage = 25f;
    public LayerMask playerLayer;
    public AudioSource spikeSound;
    
    private bool canActivate = true;

    void Update()
    {
        CheckForPlayer();
    }

   void CheckForPlayer()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, detectionRange, playerLayer))
        {
            if (canActivate && hit.collider.CompareTag("Player"))
            {
                StartCoroutine(ActivateFireTrap(hit.collider.gameObject));
                if (spikeSound != null)
                {
                spikeSound.Play();
                }
            }
        }
    }

    IEnumerator ActivateFireTrap(GameObject player)
    {
        canActivate = false;
        yield return new WaitForSeconds(fireDelay);

        
        foreach (Transform spawnPoint in fireSpawnPoints)
        {
            GameObject fire = Instantiate(fireEffectPrefab, spawnPoint.position, Quaternion.Euler(90, 0, 0));
            Destroy(fire, 2f);
        }

        yield return new WaitForSeconds(fireCooldown);
        canActivate = true;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * detectionRange);
    }
}
