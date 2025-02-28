
using Cinemachine;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject bulletHolePrefab;
    [SerializeField] float bulletHoleLifetime = 5f;
    [SerializeField] LayerMask hitLayers;
    [SerializeField] LayerMask interactionLayers;

    CinemachineImpulseSource impulseSource;

    private void Awake()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }
    public void Shoot(WeaponSO weaponSO)
    {
        muzzleFlash.Play();
        impulseSource.GenerateImpulse();
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, interactionLayers, QueryTriggerInteraction.Ignore))
        {
            GameObject vfx = Instantiate(weaponSO.HitVFXPrefab, hit.point, Quaternion.identity);
            EnemyHealth enemyHealth = hit.collider.GetComponentInParent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(weaponSO.Damage);
            }
            else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Default"))
            {
                CreateBulletHole(hit);
            }
            Destroy(vfx, 1f);
        }
    }


    void CreateBulletHole(RaycastHit hit)
    {
        if (bulletHolePrefab == null) return;

        // Đẩy lỗ đạn ra khỏi bề mặt một chút để tránh clipping
        GameObject bulletHole = Instantiate(bulletHolePrefab, hit.point + hit.normal * 0.01f, Quaternion.LookRotation(-hit.normal));

        // Xóa lỗ đạn sau một khoảng thời gian mà không làm mờ
        Destroy(bulletHole, bulletHoleLifetime);
    }
}
