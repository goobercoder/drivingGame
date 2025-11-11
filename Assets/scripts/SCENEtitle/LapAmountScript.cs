using TMPro; 
using UnityEngine;


public class LapAmountScript : MonoBehaviour
{
    public static LapAmountScript Instance;
    public TMP_InputField inputField; // Assign in the Inspector
    private int inputValue;
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

    void Start()
    {
        // Optional: add a listener that triggers whenever the user finishes editing
        inputField.onEndEdit.AddListener(OnInputEndEdit);
        inputValue = 3;
    }

    void OnInputEndEdit(string input)
    {
        // Try to convert the input text into an int
        if (int.TryParse(input, out inputValue))
        {
            Debug.Log("Converted value: " + inputValue);
        }
        else
        {
            Debug.LogWarning("Invalid input! Please enter a number.");
        }
    }

    // Optional: get the current int value from elsewhere
    public int GetValue()
    {
        return inputValue;
    }

    void OnDestroy()
    {
        // Clean up listeners to avoid memory leaks
        inputField.onEndEdit.RemoveListener(OnInputEndEdit);
    }
    void Update()
    {
        Debug.Log(inputValue);
    }
}
