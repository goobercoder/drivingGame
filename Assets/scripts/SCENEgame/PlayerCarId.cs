using UnityEngine;

public enum CarType { Player, Ai}
public class PlayerCarId : MonoBehaviour
{
    public CarType type = CarType.Player;
}