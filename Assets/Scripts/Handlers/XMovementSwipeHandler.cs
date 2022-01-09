﻿using Scripts.Utils;
using UnityEngine;

namespace Scripts.Handlers
{
    // Движение кубика влево и вправо
    public class XMovementSwipeHandler : MonoBehaviour, IMovableObjectHandler
    {
        [SerializeField] private Transform _leftBorder;
        [SerializeField] private Transform _rightBorder;
        private GameObject _movableObject;
        private ISwipeDetector _swipeDetector;
       
        public void Inject(GameObject dependency)
        {
            _movableObject = dependency;
        }
        
        private void Start()
        {
            _swipeDetector = GetComponent<ISwipeDetector>();
            Subscribe();
        }

        private void Subscribe()
        {
            _swipeDetector.onSwipe += OnSwipe;
            _swipeDetector.onSwipeEnd += OnSwipeEnd;
        }

        private void OnSwipe(Vector2 delta)
        {
            if (_movableObject == null)
            {
                return;
            }

            if (Mathf.Abs(delta.x - Mathf.Epsilon) <= 0)
                return;

            var borderDistance = Mathf.Abs(_rightBorder.position.x - _leftBorder.position.x);
            var offset = borderDistance * delta.x / Screen.width;
            var currentPos = _movableObject.transform.position;
            
            _movableObject.transform.position = new Vector3(currentPos.x + offset, currentPos.y, currentPos.z);

            if (_movableObject.transform.position.x > _rightBorder.position.x) 
                _movableObject.transform.position = _rightBorder.transform.position;
            else if (_movableObject.transform.position.x < _leftBorder.position.x)
                _movableObject.transform.position = _leftBorder.transform.position;
        }

        private void OnSwipeEnd(Vector2 delta)
        {
            _movableObject = null;
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }

        private void Unsubscribe()
        {
            if (_swipeDetector == null)
                return;
            
            _swipeDetector.onSwipe -= OnSwipe;
        }
    }
}
