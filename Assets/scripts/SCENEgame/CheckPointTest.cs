using UnityEngine;

public class CheckPointTest : MonoBehaviour
{
    public int Index;
    public bool[] triggered;
    public int Indexed;
    public int laps = 1;

    private void Awake()
    {
        ResetLap();
    }
    public void ResetLap()
    {
        triggered = new bool[Index];
        Indexed = 0;
        laps++;
    }
    public void MarkTriggered(int index)
    {
        if (!triggered[index])
        {
            triggered[index] = true;
            Indexed++;
        }
    }

    public bool CanWin()
    {
        if (Index == Indexed)
        {
            return true;
        }
        return false;
    }
}
