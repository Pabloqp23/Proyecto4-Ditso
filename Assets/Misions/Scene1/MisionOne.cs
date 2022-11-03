using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MisionOne : MonoBehaviour
{
    public Toggle toggleFight;
    public Toggle toggleBoss;
    public GameObject[] enemies;
    public bool[] deadCounter;
    public GameObject zone;
    public GameObject zone2;
    public AudioClip done;
    AudioSource audiosSource;
    void Start()
    {
        audiosSource = GetComponent<AudioSource>();
        audiosSource.clip = done;
    }
    void Update()
    {




        if (deadCounter[0] && deadCounter[1])
        {
  
            toggleFight = GetComponent<Toggle>();
            toggleFight.isOn = true;
            toggleBoss.gameObject.SetActive(true);
            enemies[2].gameObject.SetActive(true);
            zone.gameObject.SetActive(false);
            zone2.gameObject.SetActive(false);
            
        }


        ToggleOn();

    }

    public void ToggleOn()
    {
        if (!deadCounter[0] && enemies[0].GetComponent<EnemyHealth>().IsDead())
        {
            deadCounter[0] = true;
            audiosSource.Play();
        }

        if (!deadCounter[1] && enemies[1].GetComponent<EnemyHealth>().IsDead())
        {
            deadCounter[1] = true;
            audiosSource.Play();
        }
    
           
        
    }



}
