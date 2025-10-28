using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaneCollision : MonoBehaviour
{
    public GameObject winLoseMenu;
    private GameObject loseMenu;
    private GameObject WinMenu;
    
    private void Start()
    {
        // Ensure winLoseMenu is assigned in the inspector
        if (winLoseMenu != null)
        {
            loseMenu = winLoseMenu.transform.GetChild(0).gameObject;
            WinMenu = winLoseMenu.transform.GetChild(1).gameObject;

            loseMenu.SetActive(false);
            WinMenu.SetActive(false);
        }
        else
        {
            Debug.LogError("winLoseMenu is not assigned!");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Debug to check if the collision is happening
        Debug.Log("Collision Detected: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("cat"))
        {
            Debug.Log("Cat touched the plane");
            loseMenu.SetActive(true);
            StartCoroutine(WaitAndReloadScene(3));  // Wait 3 seconds before reloading
        }

        if (collision.gameObject.CompareTag("cat (ai)"))
        {
            Debug.Log("AI Cat touched the plane");
            WinMenu.SetActive(true);
            StartCoroutine(WaitAndReloadScene(3));  // Wait 3 seconds before reloading
        }
    }

    // Coroutine to wait for a few seconds before loading the scene
    //just using Thread would stop the whole game and not work cuz unity is single threaded.
    private IEnumerator WaitAndReloadScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(0);  // Replace with the correct scene index
    }
}
