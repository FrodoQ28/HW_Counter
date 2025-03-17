using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private int _number = 0;
    private bool _canCount = false;

    private void Start()
    {
        _text.text = _number.ToString();

        StartCoroutine(Counting(_canCount));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _canCount = !_canCount;
    }

    private void DisplayNextNumber()
    {
        _number++;
        _text.text = _number.ToString();
    }

    public IEnumerator Counting(bool CanCount)
    {
        bool isRunning = true;
        var waitTime = new WaitForSeconds(0.5f);
        var waitOfTrue = new WaitUntil(() => _canCount);

        while (isRunning)
        {
            yield return waitTime;

            yield return waitOfTrue;

            DisplayNextNumber();
        }
    }
}