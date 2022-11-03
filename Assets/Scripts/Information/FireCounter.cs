using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class FireCounter : MonoBehaviour
{
    public SpawnProjectile effectToSpawn;
    public Text ammo;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (effectToSpawn.GetComponent<SpawnProjectile>(). projectileAmmo != null)
        {
            ammo.text= effectToSpawn.GetComponent<SpawnProjectile>(). projectileAmmo.ToString();
        }
    }
}
