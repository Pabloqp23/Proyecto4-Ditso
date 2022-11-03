using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    public Camera cam;
    public float maximumLenght;

    private Ray rayMouse;
    private Vector3 pos;
    private Vector3 direction;
    private Quaternion rotation;
    

    void Update() {
        if(cam != null){
            RaycastHit hit;
            var mousePos = Input.mousePosition;
            rayMouse = cam.ScreenPointToRay(mousePos);
            if(Physics.Raycast (rayMouse.origin, rayMouse.direction, out hit, maximumLenght)){
                RotateToMouseDirection(gameObject, hit.point);
            }else{
                var pos = rayMouse.GetPoint(maximumLenght);
                RotateToMouseDirection(gameObject, hit.point);
            }
        }else{
            Debug.Log("No camera");
        }
    }

   void RotateToMouseDirection (GameObject obj, Vector3 destination){
        
        Vector3 restar = new Vector3(0f, Mathf.Abs(direction.y), 0f);        
        direction = (destination - obj.transform.position);  
        direction.y = 0f; 
        if (direction!= obj.transform.position)
        {
        rotation = Quaternion.LookRotation(direction);
        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, rotation, 1); 
        }                  
        
    }

    public Quaternion GetRotation(){
        return rotation;
    }
}
