using System;
using UnityEngine;

namespace Scripts.Utils
{
    public interface ISwipeDetector
    {
        event Action<Vector2> onSwipeStart;
        event Action<Vector2> onSwipe;
        event Action<Vector2> onSwipeEnd;
    }
}

