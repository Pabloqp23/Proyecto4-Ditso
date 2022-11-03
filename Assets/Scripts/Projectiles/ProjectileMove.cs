﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public float speed;
    public float fireRate;
    public GameObject muzzlePrefab;
    public GameObject hitPrefab;    
    public float projectileDamage;

    void Start()
    {
     if (muzzlePrefab != null){
         var muzzleVFX = Instantiate(muzzlePrefab, transform.position, Quaternion.identity);
         muzzleVFX.transform.forward = gameObject.transform.forward;
         var psMuzzle = muzzleVFX.GetComponent<ParticleSystem>();
         if(psMuzzle != null){
             Destroy(muzzleVFX, psMuzzle.main.duration);
         }else{
             var psChild = muzzleVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
             Destroy(muzzleVFX, psChild.main.duration);
         }
     }   
    }

    // Update is called once per frame
    void Update()
    {
        if(speed != 0){
            transform.position += transform.forward * (speed * Time.deltaTime);
        }else{
            Debug.Log("No speed");
        }
    }

     void OnCollisionEnter(Collision co) {
        speed = 0;
        ContactPoint contact = co.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;

        if(hitPrefab != null){
            var hitVFX = Instantiate(hitPrefab, pos, rot);
            var psHit = hitVFX.GetComponent<ParticleSystem>();
            if(co.gameObject.tag == "Enemy"){
                Debug.Log("Es enemigo!");
                co.gameObject.GetComponent<EnemyHealth>().DecreaseHealth(projectileDamage);
            }
         if(psHit != null){
             Destroy(hitVFX, psHit.main.duration);
         }else{
             var psChild = hitVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
             Destroy(hitVFX, psChild.main.duration);
         }
        }
        Destroy(gameObject);
    }
}