﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Prelude : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject toggleKillEnemies;
    public GameObject zone;
    public bool activeFightMision1;
    public float range;
    public Vector3 distance1;
    public float diff1;
    public GameObject prelude;
    public Vector3 distance2;
    public float diff2;
    public GameObject player;
    
    void Start()
    {
        activeFightMision1 = false;
    }

    // Update is called once per frame
    void Update()
    {
            if (!activeFightMision1)
        {
            inRange();
        }
     
    }
     public void inRange()
    {
        distance2 = enemies[0].transform.position - player.transform.position;
        diff2 = distance2.sqrMagnitude;
        distance1 = enemies[1].transform.position - player.transform.position;
        diff1 = distance1.sqrMagnitude;
        if (diff1 < range && diff2 < range)
        {
            prelude.gameObject.SetActive(false);
            toggleKillEnemies.gameObject.SetActive(true);
            zone.gameObject.SetActive(true);
            activeFightMision1 = true;
            //GetComponent<Animation>().CrossFade(attack.name);
        }

    }
}
