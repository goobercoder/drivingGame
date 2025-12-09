using UnityEngine;
using UnityEngine.UI; // Required for UI components like Slider
using TMPro; // Required for TMP_Text

public class SliderScript : MonoBehaviour
{
    public static SliderScript instance;
    public string sliderObjectName = "SliderObjectName"; // Name of the Slider GameObject
    public string textObjectName = "TextObjectName"; // Name of the TMP_Text GameObject
    
    public Slider mySlider; // Reference to the Slider
    public TMP_Text valueText; // Reference to the TMP_Text for displaying the value

    void Awake()
    {
       
    }

    void Start()

    {
        GameObject sliderObject = GameObject.Find(sliderObjectName);
        if (sliderObject != null)
        {
            mySlider = sliderObject.GetComponent<Slider>(); // Get the Slider component
        }
        else
        {
            Debug.LogWarning($"Slider with name {sliderObjectName} not found.");
        }
        GameObject textObject = GameObject.Find(textObjectName);
        if (textObject != null)
        {
            valueText = textObject.GetComponent<TMP_Text>(); // Get the TMP_Text component
        }
        else
        {
            Debug.LogWarning($"TMP_Text with name {textObjectName} not found.");
        }
        // Ensure that the Slider and Text components are correctly set
        if (mySlider != null && valueText != null)
        {
            // Set the initial value of the text (optional)
            valueText.text = mySlider.value.ToString("F2");

            // Add listener to update the Text when slider value changes
            mySlider.onValueChanged.AddListener(UpdateText);
        }
    }

    void UpdateText(float value)
    {
        // Update the Text UI element to display the current value of the slider
        if (valueText != null)
        {
            valueText.text = value.ToString("F2"); // Optional formatting (2 decimal places)
        }
    }

    void OnDestroy()
    {
        // Clean up by removing the listener when the script is destroyed
        if (mySlider != null)
        {
            mySlider.onValueChanged.RemoveListener(UpdateText);
        }
    }
}
