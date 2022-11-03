using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Information : MonoBehaviour
{
   public GameObject player;
    public GameObject info;  
    public float range;
     public Vector3 distance1;
    public float diff1;
    public GameObject firstPanel;
    
      void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     inRange();   
    }
     public void inRange()
    {
       
        distance1 = info.transform.position - player.transform.position;
        diff1 = distance1.sqrMagnitude;
        if (diff1 < range)
        {
            firstPanel.gameObject.SetActive(true);
            
           
        }else
        {
           firstPanel.gameObject.SetActive(false);   
        }
    }
}
