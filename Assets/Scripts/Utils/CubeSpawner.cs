using System.Collections;
using UnityEngine;

namespace Scripts.Utils
{   
    public class CubeSpawner : MonoBehaviour
    {
        [SerializeField] private float _spawnDelay = 0.3f;
        [SerializeField] private GameObject _cubePrefab;
        [SerializeField] private GameObject _swipeDetectorObject; // объект с которого получаем компонент

        private CubeDependencyInjector[] _cubeDependencies;        
        private ISwipeDetector _swipeDetector;
        private Coroutine _spawnCoroutine;
        
        private void Start()
        {
            _swipeDetector = _swipeDetectorObject.GetComponent<ISwipeDetector>();
            _cubeDependencies = FindObjectsOfType<CubeDependencyInjector>();
            Subscribe();
        }

        private void Subscribe()
        {
            _swipeDetector.onSwipeEnd += OnSwipeEnd;
        }

        private void Unsubscribe()
        {
            _swipeDetector.onSwipeEnd -= OnSwipeEnd;
        }

        private void OnSwipeEnd(Vector2 delta)
        {
            if (_spawnCoroutine == null)
                _spawnCoroutine = StartCoroutine(SpawnWithDelay());
        }

        private IEnumerator SpawnWithDelay()
        {
            yield return null; // ожидание 1 кадра, в случае передачи 0
            yield return new WaitForSeconds(_spawnDelay);
            if (_cubePrefab!=null)
            {
                // новый экземпляр затратная операция, оптимальнее использовать object pull
                var instance = Instantiate(_cubePrefab, transform.position, Quaternion.identity);
                InjectCube(instance.gameObject);
            }  
            _spawnCoroutine = null;
        }

        private void InjectCube(GameObject cube)
        {
            foreach (var dependency in _cubeDependencies)
            {
                dependency.Cube = cube;         
            }
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }
    }
}
