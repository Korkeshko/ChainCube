using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Utils
{
    // Сообщает другим компонетам о движении/клике мышки
    public class MouseSwipeDetector : MonoBehaviour, ISwipeDetector
    {
        public event Action<Vector2> onSwipeStart;
        public event Action<Vector2> onSwipe;
        public event Action<Vector2> onSwipeEnd;

        private bool _isSwipe;
        private Vector3 _lastPosition = new Vector2();

        private void Update()
        {            
            if (!Input.GetMouseButton(0))
            {
                if (_isSwipe)
                {
                    _isSwipe = false;
                    // Считываем конечную позицию swipe
                    onSwipeEnd?.Invoke(_lastPosition);                  
                }
                
                // Считываем позицию курсора без действия
                _lastPosition = Input.mousePosition;
                return;
            }

            if (!_isSwipe)
            {
                _isSwipe = true;
                // фиксируем начальную позицию swipe 
                onSwipeStart?.Invoke(Input.mousePosition - _lastPosition);
            }

            onSwipe?.Invoke(Input.mousePosition - _lastPosition);
            // считываем текущую позицию swipe
            _lastPosition = Input.mousePosition;
        }
    }
}