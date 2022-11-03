using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class KillAllSlimes : MonoBehaviour
{
  public Toggle killEnemies;
    public Toggle toggleRange;
    public GameObject[] enemies;
    public bool[] deadCounter;
    public GameObject zone;
    public AudioClip done;
    AudioSource audiosSource;
    void Start()
    {
           audiosSource = GetComponent<AudioSource>();
        audiosSource.clip = done;
    }

    // Update is called once per frame
    void Update()
    {
        
  
        if (deadCounter[0] && deadCounter[1]&& deadCounter[2]&& deadCounter[3]&& deadCounter[4]&& deadCounter[5]&& deadCounter[6]&& deadCounter[7]&& deadCounter[8]&& deadCounter[9])
        {
  
            killEnemies = GetComponent<Toggle>();
            killEnemies.isOn = true;
            toggleRange.gameObject.SetActive(true);
            enemies[10].gameObject.SetActive(true);
            zone.gameObject.SetActive(false);
            
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
    if (!deadCounter[2] && enemies[2].GetComponent<EnemyHealth>().IsDead())
        {
            deadCounter[2] = true;
            audiosSource.Play();
        }

        if (!deadCounter[3] && enemies[3].GetComponent<EnemyHealth>().IsDead())
        {
            deadCounter[3] = true;
            audiosSource.Play();
        }
    if (!deadCounter[4] && enemies[4].GetComponent<EnemyHealth>().IsDead())
        {
            deadCounter[4] = true;
            audiosSource.Play();
        }

        if (!deadCounter[5] && enemies[5].GetComponent<EnemyHealth>().IsDead())
        {
            deadCounter[5] = true;
            audiosSource.Play();
        }
    if (!deadCounter[6] && enemies[6].GetComponent<EnemyHealth>().IsDead())
        {
            deadCounter[6] = true;
            audiosSource.Play();
        }

        if (!deadCounter[7] && enemies[7].GetComponent<EnemyHealth>().IsDead())
        {
            deadCounter[7] = true;
            audiosSource.Play();
        }
    if (!deadCounter[8] && enemies[8].GetComponent<EnemyHealth>().IsDead())
        {
            deadCounter[8] = true;
            audiosSource.Play();
        }

        if (!deadCounter[9] && enemies[9].GetComponent<EnemyHealth>().IsDead())
        {
            deadCounter[9] = true;
            audiosSource.Play();
        }
    
           
        
    }

}
