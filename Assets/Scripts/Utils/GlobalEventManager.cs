using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager
{
    public static UnityEvent<int> OnIncrementMove = new UnityEvent<int>();

    public static void SendIncrementMove(int Count)
    {
        OnIncrementMove.Invoke(Count);
    }

}
