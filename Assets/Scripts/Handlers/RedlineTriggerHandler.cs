using UnityEngine;
using Scripts.Utils;
using UnityEngine.SceneManagement;
using TMPro;

public class RedlineTriggerHandler : MonoBehaviour
{   
    [SerializeField] int _scoreCounter;
    [SerializeField] TextMeshProUGUI _scoreText;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Cube")
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else   
            other.gameObject.tag = "Cube";   
            DataHolder._score = _scoreCounter++;
            _scoreText.text = _scoreCounter.ToString(); 
    }
}
