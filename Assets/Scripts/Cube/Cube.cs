using UnityEngine;
using UnityEngine.UI;

public class Cube : MonoBehaviour
{
    public int Value { get; private set; }
    public int Points => IsEmpty ? 0 : (int)Mathf.Pow(2, Value);

    public bool IsEmpty => Value == 0;

    public const int MaxValue = 11;
    [SerializeField] private Image image;

    public void SetValue(int value)
    {
        Value = value;

        UpdateCell();
    }

    public void UpdateCell()
    {

    }
}
