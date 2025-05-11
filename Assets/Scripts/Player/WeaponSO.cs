using UnityEngine;
[CreateAssetMenu(fileName = "SO", menuName = "Scriptable Objec/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    public GameObject weaoponPrefab;
    public int Damage = 1;
    public float FireRate = .5f;
    public GameObject HitVFXPrefab;
    public bool isAutomatic = false;
    public bool CanZoom = false;
    public float ZoomAmount = 10f;
    public float ZoomRotationSpeed = .3f;
    public int magazineSize = 12;
    public AudioClip sound;
    public bool isMachineGun;
}
