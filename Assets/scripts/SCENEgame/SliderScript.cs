using UnityEngine;
using UnityEngine.UI; // Required for UI components like Slider and Text
using TMPro; // Required for TMP_Text

public class SliderScript : MonoBehaviour
{
    public Slider mySlider; 
    public TMP_Text valueText;

    void Start()
    {
        

        

        // Set the initial value of the text (optional)
        valueText.text = mySlider.value.ToString("F2");

        // Add listener to update the Text when slider value changes
        mySlider.onValueChanged.AddListener(UpdateText);
    }

    void UpdateText(float value)
    {
        // Update the Text UI element to display the current value of the slider
        valueText.text = value.ToString("F2"); // Optional formatting (2 decimal places)
    }

    void OnDestroy()
    {
        // Clean up by removing the listener when the script is destroyed
        mySlider.onValueChanged.RemoveListener(UpdateText);
    }
}
