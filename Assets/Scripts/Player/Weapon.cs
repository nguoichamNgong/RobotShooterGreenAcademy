using Cinemachine;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject bulletHolePrefab;
    [SerializeField] float bulletHoleLifetime = 5f;
    [SerializeField] LayerMask hitLayers;
    [SerializeField] LayerMask interactionLayers;
    [SerializeField] AudioSource sound;

    private CinemachineImpulseSource impulseSource;
    private WeaponSO weaponSO;

    private void Awake()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    private void Update()
    {
        // Nếu là súng máy, dừng âm thanh khi nhả chuột trái
        if (weaponSO != null && weaponSO.isMachineGun)
        {
            if (Input.GetMouseButtonUp(0) && sound.isPlaying)
            {
                sound.Stop();
            }
        }
    }

    // Hàm này được gọi từ ActiveWeapon.cs
    public void SetWeaponData(WeaponSO so)
    {
        weaponSO = so;
    }

    public void Shoot(WeaponSO weaponSO)
    {
        if (sound != null) sound.Play();
        if (muzzleFlash != null) muzzleFlash.Play();
        if (impulseSource != null) impulseSource.GenerateImpulse();

        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, interactionLayers, QueryTriggerInteraction.Ignore))
        {
            if (weaponSO.HitVFXPrefab != null)
            {
                GameObject vfx = Instantiate(weaponSO.HitVFXPrefab, hit.point, Quaternion.identity);
                Destroy(vfx, 1f);
            }

            EnemyHealth enemyHealth = hit.collider.GetComponentInParent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(weaponSO.Damage);
            }
            else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Default"))
            {
                CreateBulletHole(hit);
            }
        }
    }

    void CreateBulletHole(RaycastHit hit)
    {
        if (bulletHolePrefab == null) return;

        GameObject bulletHole = Instantiate(
            bulletHolePrefab,
            hit.point + hit.normal * 0.01f,
            Quaternion.LookRotation(-hit.normal)
        );

        Destroy(bulletHole, bulletHoleLifetime);
    }
}
