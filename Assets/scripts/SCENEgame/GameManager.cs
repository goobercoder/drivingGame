using UnityEngine;
using UnityEngine.UI; // Required for UI components like Slider and Text
using TMPro; // Required for TMP_Text

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TMP_Text valueText;

    public int lapsToWin = 3;

    [SerializeField] private CheckPointTest playerCT;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instance != null && Instance != this)
        {

        }
        Instance = this;
    }
    void Start()
    {
        lapsToWin = LapAmountScript.Instance.GetValue();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(lapsToWin);
        valueText.text = "Laps: " + playerCT.laps.ToString() + "/" + lapsToWin.ToString();
    }
}
