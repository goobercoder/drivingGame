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
                
                Debug.Log("cat touched the plane");

                //make gui element for winning

                Thread. Sleep(3000);

                

            }
            if (collision.gameObject.CompareTag("cat (ai)"))
            {

                Debug.Log("ai cat touched the plane");

                //make gui element for losing

                Thread. Sleep(3000);

            }
        }
    }
}
