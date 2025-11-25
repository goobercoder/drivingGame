using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Required for UI components like Slider and Text
using TMPro; // Required for TMP_Text

public class PlaneCollision : MonoBehaviour
{
    public TMP_Text winLoseMenu;
    



    private void OnCollisionEnter(Collision collision)
    {
        // Debug to check if the collision is happening
        Debug.Log("Collision Detected: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("cat"))
        {
            Debug.Log("Cat touched the plane");
            WinnerUiManager(false);
            
        }

        if (collision.gameObject.CompareTag("cat (ai)"))
        {
            Debug.Log("AI Cat touched the plane");
            WinnerUiManager(true);
            
        }
    }

    
    private void WinnerUiManager(bool won)
    {
        
        if (won)
        {
            winLoseMenu.text = "Did u ate shit? idk lets find out: Nop u good boi";
            winLoseMenu.color = Color.green;
            WinManager.Instance.WinManagerFunc(true, true);
        }
        else{
            winLoseMenu.text = "Did u ate shit? idk lets find out: Yuh uh u baad";
            winLoseMenu.color = Color.red;
            WinManager.Instance.WinManagerFunc(true, false);
        }
    }
}