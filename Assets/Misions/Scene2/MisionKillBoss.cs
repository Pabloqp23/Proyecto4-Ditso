using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MisionKillBoss : MonoBehaviour
{
    public Toggle toggleBoss;
     public GameObject enemy;
     public GameObject nextMision;
    public GameObject gem;
    public bool  deadCounter;

    // Update is called once per frame
    void Update()
    {
        if (deadCounter)
                    {
                        toggleBoss = GetComponent<Toggle>();

                        toggleBoss.isOn = true;
                        nextMision.gameObject.SetActive (true);
                        gem.gameObject.SetActive (true);
                    }
                    ToggleOn();
    }
    public void ToggleOn()
    { 
                    if (!deadCounter && enemy.GetComponent<EnemyHealth>().IsDead())
                    {
                        deadCounter= true;
                    }
                   
      }
}
