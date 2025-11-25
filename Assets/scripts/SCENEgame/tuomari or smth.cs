using UnityEngine;
using UnityEngine.UI; // Required for UI components like Slider and Text
using TMPro; // Required for TMP_Text

public class tuomariorsmth : MonoBehaviour
{
    private bool playerWon = false;
    void Start()
    {
        
    }

    private bool winnerExists = false;
    public TMP_Text winnerText;
    private void OnTriggerEnter(Collider cat)
    {

        var id = cat.GetComponent<PlayerCarId>();
        var tarkastaja = cat.GetComponent<CheckPointTest>();
        if (tarkastaja.CanWin())
        {
            if (tarkastaja.laps == GameManager.Instance.lapsToWin && !winnerExists)
            {
                winnerExists = true;
                if (id.type == CarType.Player) //this don work somhow
                {
                    playerWon = true;
                }

                WinnerUiManager(playerWon);
            }
            Debug.Log("!!Winner: " + id);
            tarkastaja.ResetLap();
        }

    }
    private void WinnerUiManager(bool won)
    {
        
        if (won)
        {
            winnerText.text = "Did u ate shit? idk lets find out: Nop u good boi";
            winnerText.color = Color.green;
            WinManager.Instance.WinManagerFunc(true, true);
        }
        else{
            winnerText.text = "Did u ate shit? idk lets find out: Yuh uh u baad";
            winnerText.color = Color.red;
            WinManager.Instance.WinManagerFunc(true, false);
        }
    }
}
