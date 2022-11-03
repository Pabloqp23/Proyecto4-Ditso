using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

  public int index;
    // Start is called before the first frame update
   void OnTriggerEnter3D(Collider2D other)
    {
      if (other.CompareTag("Player"))
      {
          SceneManager.LoadScene(index);
      }
        

    }

}
