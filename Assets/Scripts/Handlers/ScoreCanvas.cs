using UnityEngine;
using Scripts.Utils;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreCanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreValue;

    void Start()
    {
        // можно было использовать PlayerPrefs   
        _scoreValue.text = DataHolder._score.ToString();
    }

    public void StartHandler() {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void ExitHandler() {
        Application.Quit();
    }
}
