using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limitMove : MonoBehaviour
{
    public bool maxWall = false;
    public GameObject blackHole;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Limiter"){
            Debug.Log("hitted");
            maxWall = true;
            StartCoroutine(WaitAndExecute());
           
        

        }
    }

      IEnumerator WaitAndExecute()
    {
        // Wait for 10 seconds
        yield return new WaitForSeconds(5f);
         this.blackHole.gameObject.SetActive(true);
         
    }

     
 

}
