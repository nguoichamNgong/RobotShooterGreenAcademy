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
    private void Start()
    {
        player = FindFirstObjectByType<PlayerHealth>();
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
            Projectile newprojectTile = Instantiate(projectilePrefab, projectileSpawnPoint.position, turretHead.rotation).GetComponent<Projectile>();
            newprojectTile.transform.LookAt(targetPoint);
            newprojectTile.Init(damage);
        }

    }
}
