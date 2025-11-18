using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaneCollision : MonoBehaviour
{
   
    
    private void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Debug to check if the collision is happening
        Debug.Log("Collision Detected: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("cat"))
        {
            //tp to last cp
        }

        if (collision.gameObject.CompareTag("cat (ai)"))
        {
            //tp to last cp
        }
    }


    
}
