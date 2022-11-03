using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MisionKillRabbitBoss : MonoBehaviour
{
    public Toggle toggleBoss;
    public GameObject nextMision;
    public GameObject gem;
    public GameObject enemy;

    public bool deadCounter;
    public AudioClip done;
    AudioSource audiosSource;

    // Start is called before the first frame update
    void Start()
    {
        audiosSource = GetComponent<AudioSource>();
        audiosSource.clip = done;
    }

    // Update is called once per frame
    void Update()
    {
        if (deadCounter)
        {
            toggleBoss = GetComponent<Toggle>();
            toggleBoss.isOn = true;    
           
            nextMision.gameObject.SetActive(true);
            gem.gameObject.SetActive(true);
        }
        ToggleOn();

    }
    public void ToggleOn()
    {
        if (!deadCounter && enemy.GetComponent<EnemyHealth>().IsDead())
        {
            deadCounter = true;
             audiosSource.Play();
            
        }

    }

}
