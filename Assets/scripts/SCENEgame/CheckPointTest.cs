using UnityEngine;

public class CheckPointTest : MonoBehaviour
{
    public int Index;
    public bool[] triggered;
    public int Indexed;

    private void Awake()
    {
        ResetLap();
    }
    public void ResetLap()
    {
        triggered = new bool[Index];
        Indexed = 0;
    }
    public void MarkTriggered(int index)
    {
        if (!triggered[index])
        {
            triggered[index] = true;
            Indexed++;
        }
    }

    public bool canWin()
    {
        if (Index == Indexed)
        {
            return true;
        }
        return false;
    }
}
