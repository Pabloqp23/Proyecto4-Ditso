using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Health Up", menuName = "Inventory/HealthUp")]
public class HealthUp : Item
{
    public float healthModifier;
    Fighter health;
     void Start()
    {
        health = Fighter.instance;
        
    }
    public override void Use()
    {
        base.Use();
        ApplyEffect();
    }
    public void ApplyEffect()
    {
        Fighter.instance.IncrementHealth(healthModifier);
        
    }
}
