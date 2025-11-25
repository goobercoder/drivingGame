using System.Collections;  // This is the namespace that contains IEnumerator
using UnityEngine;
using UnityEngine.SceneManagement;  // Don't forget to add this for SceneManager

public class WinManager : MonoBehaviour
{
    public static WinManager Instance;
    private bool gameEndDeclared = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        // Ensure only one instance exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist between scenes
        }
        else if (Instance != this)
        {
            Destroy(gameObject); // Destroy duplicates
            return;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void WinManagerFunc(bool gameEnd = false, bool playerWon = false)
    {
        if (gameEnd && !gameEndDeclared)
        {
            if (playerWon)
            {
                Debug.Log("player won");
                gameEndDeclared = true;
                StartCoroutine(WaitAndReloadScene(1));
            }
            else
            {
                Debug.Log("player lost");
                gameEndDeclared = true;
                StartCoroutine(WaitAndReloadScene(1));
            }
            


        }
    }
    private IEnumerator WaitAndReloadScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(0);  // Replace with the correct scene index
    }
}


    
