using UnityEngine;
using UnityEngine.UI; // Required for UI components like Slider and Text
using TMPro; // Required for TMP_Text

public class UpdatelapsUi : MonoBehaviour
{
    public static UpdatelapsUi Instance;
    public TMP_Text valueText;

    [SerializeField] private CheckPointTest playerCT;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instance != null && Instance != this)
        {

        }
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        valueText.text = "Laps: " + playerCT.laps.ToString() + "/3";
    }
}
