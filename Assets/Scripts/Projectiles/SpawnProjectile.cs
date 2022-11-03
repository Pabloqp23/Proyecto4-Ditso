using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour
{
     #region Singleton
    public static SpawnProjectile instance;
    void Awake()
    {
        instance= this;
    }
    #endregion
   
    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();
    public RotateToMouse rotateToMouse;
    public int projectileAmmo;

    private GameObject effectToSpawn;
    private float timeToFire = 0;

    void Start()
    {
        effectToSpawn = vfx[0];
        //projectileAmmo = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && Time.time >= timeToFire){
            if(projectileAmmo > 0){
                timeToFire = Time.time + 1 / effectToSpawn.GetComponent<ProjectileMove>(). fireRate;
                SpawnVFX();
                projectileAmmo -= 1;
                Debug.Log("Quedan " + projectileAmmo + "proyectiles");
            }else{
                Debug.Log("No more ammo");
            }
        }
    }

    void SpawnVFX(){
        GameObject vfx;

        if (firePoint != null){
            vfx = Instantiate (effectToSpawn, firePoint.transform.position, Quaternion.identity);
            if(rotateToMouse != null){
                vfx.transform.localRotation = rotateToMouse.GetRotation();
            }
        }else{
            Debug.Log("No firepoint");
        }
    }
     public void Reaload(int ammo)
    {

        projectileAmmo = projectileAmmo + ammo;
       // float calculateHealth = currentHealth / maxHealth;
        
        //SetHealthBar(calculateHealth);
        //if (currentHealth < 0)
        //{
          //  currentHealth = 0;
        //}

    }
}
