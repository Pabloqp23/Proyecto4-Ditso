using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class MisionTwo : MonoBehaviour
{
 public Toggle toggleBoss;
 public Toggle toggleRange;
    public GameObject enemy;
    public GameObject player;
    public bool  activeMision;
    public float range;
    public Vector3 distance;
     public float diff;
    void Update()
    {
                    
          FirstToggleOn();
          inRange();
       
    }
    
      public void FirstToggleOn()
    { 
                if (activeMision)
                    {
                    toggleBoss.gameObject.SetActive (true);
                  
                     toggleRange = GetComponent<Toggle>();

                    toggleRange.isOn = true;

                    }   
    }
      public void inRange()
    {
distance= enemy.transform.position- player.transform.position;
diff= distance.sqrMagnitude;
        if (diff < range)
        {
            
            activeMision=true;
            //GetComponent<Animation>().CrossFade(attack.name);
        }
     
    }   
    
}
