using UnityEngine;
using TMPro;

public class NumberOfMovesText : MonoBehaviour
{
    private void Awake() 
    {
        GlobalEventManager.OnIncrementMove.AddListener(countMoves => 
        {
            GetComponent<TextMeshProUGUI>().text = "Moves: " + countMoves;
        });
    }
}
