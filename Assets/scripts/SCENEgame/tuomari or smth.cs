using UnityEngine;

public class tuomariorsmth : MonoBehaviour
{
    private void OnTriggerEnter(Collider cat)
    {
        var id = cat.GetComponent<PlayerCarId>();
        var tarkastaja = cat.GetComponent<CheckPointTest>();
        if (tarkastaja.CanWin())
        {
            Debug.Log("!!Winner: " + id);
            tarkastaja.ResetLap();
        }
        
    }
}
