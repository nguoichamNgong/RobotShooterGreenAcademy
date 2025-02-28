using UnityEngine;

public class AmmoPickup : Pickcup
{
    [SerializeField] int ammoAmount = 100;

    protected override void OnPickup(ActiveWeapon activeWeapon)
    {
        activeWeapon.AdjustAmmo(ammoAmount);
    }
}
