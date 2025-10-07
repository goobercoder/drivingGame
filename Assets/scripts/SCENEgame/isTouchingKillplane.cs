using UnityEngine;

public class PlaneCollision : MonoBehaviour
{
    private bool won = false;
    private bool lost = false;
    // Example of what to do when Object A touches the plane
    private void OnCollisionEnter(Collision collision)
    {
        if (won == true || lost == true)
        {
            if (collision.gameObject.CompareTag("cat"))
            {
                // Object A touches the plane
                Debug.Log("Object A touched the plane");

                lost = true;

            }
            if (collision.gameObject.CompareTag("cat (ai)"))
            {

                Debug.Log("Object B touched the plane");

                won = true;

            }
        }
    }
}