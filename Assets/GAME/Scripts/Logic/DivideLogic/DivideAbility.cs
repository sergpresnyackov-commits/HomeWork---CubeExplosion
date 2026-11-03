using UnityEngine;

public class DivideAbility : MonoBehaviour
{
    private int _divideCount;

    public int GetDivideCount()
    {
        return _divideCount;
    }

    public void Init(int divideCount)
    {
        if (divideCount < 0)
        {
            divideCount = 0;
        }

        _divideCount = divideCount;
    }
}