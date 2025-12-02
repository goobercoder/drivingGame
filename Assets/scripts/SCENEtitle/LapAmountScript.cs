using TMPro;
using UnityEngine;

public class LapAmountScript : MonoBehaviour
{
    public static LapAmountScript Instance;
    public string inputFieldObjectName = "InputFieldObjectName"; // Name of the TMP_InputField GameObject
    public TMP_InputField inputField; // Reference to the TMP_InputField
    public int inputValue;

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
        // Find the TMP_InputField by name if it's not set in the inspector
        if (inputField == null)
        {
            GameObject inputObject = GameObject.Find(inputFieldObjectName);
            if (inputObject != null)
            {
                inputField = inputObject.GetComponent<TMP_InputField>();
            }
            else
            {
                Debug.LogWarning($"No TMP_InputField found with the name {inputFieldObjectName}.");
            }
        }
        if (inputField != null)
        {
            // Add listener to trigger when the user finishes editing
            inputField.onEndEdit.AddListener(OnInputEndEdit);
        }

        // Set default value for the input
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

    // Method to get the current input value
    public int GetValue()
    {
        return inputValue;
    }

    void OnDestroy()
    {
        // Clean up listeners to avoid memory leaks
        if (inputField != null)
        {
            inputField.onEndEdit.RemoveListener(OnInputEndEdit);
        }
    }

    void Update()
    {
        // Optional: Debug output
        // Debug.Log(inputValue);
    }
}
