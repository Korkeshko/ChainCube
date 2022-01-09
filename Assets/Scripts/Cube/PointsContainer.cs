using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Cube
{
    public class PointsContainer : MonoBehaviour
    {
        [SerializeField] protected long _points;

        const int _maxValue = 2048;

        public long points
        {
            get => _points;
            set
            {
                if (_maxValue == value)
                {
                    Time.timeScale = 0;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                    
                
                if (_points == value)
                    return;

                _points = value;
                onPointsChanged?.Invoke(_points);
            }
        }

        public event Action<long> onPointsChanged;
    }
}
