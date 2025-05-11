using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform turretHead;
    [SerializeField] Transform targetPoint;
    [SerializeField] Transform projectileSpawnPoint;
    [SerializeField] float fireRate = 3f;
    [SerializeField] int damage = 2;

    PlayerHealth player;
    AudioManager audioManager;  // Reference to the AudioManager

    private void Start()
    {
        player = FindObjectOfType<PlayerHealth>();  // Find PlayerHealth in the scene
        audioManager = FindObjectOfType<AudioManager>();  // Find AudioManager in the scene
        StartCoroutine(FireRoutine());
    }

    void Update()
    {
        turretHead.LookAt(targetPoint);
    }

    IEnumerator FireRoutine()
    {
        while (player)
        {
            yield return new WaitForSeconds(fireRate);

            // Instantiate the projectile
            Projectile newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, turretHead.rotation).GetComponent<Projectile>();
            newProjectile.transform.LookAt(targetPoint);
            newProjectile.Init(damage);

            // Play the firing sound using AudioManager
            if (audioManager != null)
            {
                audioManager.PlaySFX(audioManager.gun);  // Play the "gun" firing sound
            }
        }
    }
}
