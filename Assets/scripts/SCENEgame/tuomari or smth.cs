using UnityEngine;

public class tuomariorsmth : MonoBehaviour
{
    private void OnTriggerEnter(Collider cat)
    {
        var id = cat.GetComponent<PlayerCarId>();
        Debug.Log("Winner: " + id);
    }
}
