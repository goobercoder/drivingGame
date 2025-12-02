using UnityEngine;
using TMPro; // Required for TMP_Text
using UnityEngine.SceneManagement; // Required for scene management

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TMP_Text valueText;
    public int lapsToWin = 3;
    private GameObject playerObject;

    [SerializeField] private CheckPointTest playerCT; // Reference to player CheckPointTest

    void Awake()
    {
        // Ensure there's only one instance of GameManager and that it persists across scenes
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);  // Destroy duplicate instance
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);  // Keep GameManager alive across scene loads

        // Register to the sceneLoaded event to handle reconnection of references
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        // Initialize lapToWin from another manager or script if needed
        lapsToWin = LapAmountScript.Instance.GetValue();

        // Ensure that valueText is assigned via the inspector or fallback to find it by name
        if (valueText == null)
        {
            valueText = GameObject.Find("Laps")?.GetComponent<TMP_Text>();
            if (valueText == null)
            {
                Debug.LogError("Laps Text UI not found. Please make sure the 'Laps' GameObject exists.");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Update the UI text with the player's current lap progress if playerCT exists
        if (playerCT != null && valueText != null)
        {
            valueText.text = "Laps: " + playerCT.laps.ToString() + "/" + lapsToWin.ToString();
        }
    }

    // This method is called when a new scene is loaded
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Ensure the player object is found by name ("cat") when the scene is loaded
        playerObject = GameObject.Find("cat");
        if (playerObject != null)
        {
            playerCT = playerObject.GetComponent<CheckPointTest>();
        }
        else
        {
            Debug.LogWarning("Player GameObject 'cat' not found in the scene.");
        }

        // Reassign valueText if it's not already assigned
        if (valueText == null)
        {
            valueText = GameObject.Find("Laps")?.GetComponent<TMP_Text>();
            if (valueText == null)
            {
                Debug.LogError("Laps Text UI not found in the scene.");
            }
        }

        // Update the UI text with the player's current lap progress
        if (playerCT != null && valueText != null)
        {
            valueText.text = "Laps: " + playerCT.laps.ToString() + "/" + lapsToWin.ToString();
        }
    }

    // Optionally, you can unsubscribe from the event in OnDestroy
    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
