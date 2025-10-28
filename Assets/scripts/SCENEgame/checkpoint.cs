using UnityEngine;

public class checkpoint : MonoBehaviour
{
    public int orderIndex = 0;
    private void OnTriggerEnter(Collider cat)
    {
        var id = cat.GetComponent<PlayerCarId>();
        Debug.Log("ChP" + orderIndex + " " + id);
        var tarkastaja = cat.GetComponent<CheckPointTest>();
        tarkastaja.MarkTriggered(orderIndex);
    }
}
