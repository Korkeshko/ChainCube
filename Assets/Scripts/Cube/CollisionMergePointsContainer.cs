using UnityEngine;

namespace Scripts.Cube
{
    [RequireComponent(typeof(PointsContainerCollisionDetector), typeof (PointsContainer))]
    public class CollisionMergePointsContainer : MonoBehaviour
    {
        private PointsContainer _pointsContainer;
        private PointsContainerCollisionDetector _detector;
        private AudioSource _popSound;

        private void Start()
        {
            _pointsContainer = GetComponent<PointsContainer>();
            _detector = GetComponent<PointsContainerCollisionDetector>();
            _popSound = GetComponent<AudioSource>();
            Subscribe();
        }

        private void Subscribe()
        {
            _detector.onCollisionContinue += OnPointsContainerCollision;
        }
        
        private void Unsubscribe()
        {
            _detector.onCollisionContinue -= OnPointsContainerCollision;
        }

         private void OnPointsContainerCollision(PointsContainer col)
        {
            if (col.points == _pointsContainer.points)
            {
                _popSound.Play();
                _pointsContainer.points *= 2;                
                Destroy(col.gameObject);   
            }
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }
    }
}
