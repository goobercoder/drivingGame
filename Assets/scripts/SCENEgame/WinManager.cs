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
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Destroy duplicates
        }
        else 
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist between scenes
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
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }
    void OnEnable()
{
    SceneManager.sceneLoaded += OnSceneLoaded;
}

void OnDisable()
{
    SceneManager.sceneLoaded -= OnSceneLoaded;
}

void OnSceneLoaded(Scene s, LoadSceneMode mode)
{
    if (s.buildIndex == 1)  // if your GAME scene is index 1
    {
        gameEndDeclared = false;  // reset automatically
    }
}
}


    
