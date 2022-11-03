using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ammo Up", menuName = "Inventory/AmmoUp")]
public class AmmoReload : Item
{
    public int reloadedAmmo;
    SpawnProjectile projectile;
    // Start is called before the first frame update
    void Start()
    {
        projectile= SpawnProjectile.instance;
    }
     public override void Use()
    {
        base.Use();
        ApplyEffect();
    }
    public void ApplyEffect()
    {
        SpawnProjectile.instance.Reaload(reloadedAmmo);
    }
}
