using UnityEngine;
using Scripts.Utils;
using UnityEngine.SceneManagement;

public class RedlineTriggerHandler : MonoBehaviour
{   
    [SerializeField] int _scoreCounter;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Cube")
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else   
            other.gameObject.tag = "Cube";   
            DataHolder._score = _scoreCounter++;

            GlobalEventManager.SendIncrementMove(_scoreCounter);
            
    }
}
