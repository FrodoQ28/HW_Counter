using TMPro;
using UnityEngine;

public class DisplayCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Counter _counter;

    private int _defaultNumber = 0;

    private void OnEnable()
    {
        _counter.NumberChanged += DisplayNumber;
    }

    private void Start()
    {
        _text.text = _defaultNumber.ToString();
    }

    private void OnDisable()
    {
        _counter.NumberChanged -= DisplayNumber;
    }

    private void DisplayNumber()
    {
        _text.text = _counter.Number.ToString();
    }
}
