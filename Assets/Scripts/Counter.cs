using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private Coroutine _counting;
    private int _number = 0;

    public event Action NumberChanged;

    public int Number => _number;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_counting != default)
            {
                StopCounting();
            }
            else
            {
                _counting = StartCoroutine(Counting());
            }
        }
    }

    private void StopCounting()
    {
        if (_counting != null)
            StopCoroutine(_counting);

        _counting = default;

    }

    public IEnumerator Counting()
    {
        var waitTime = new WaitForSeconds(0.5f);

        while (enabled)
        {
            yield return waitTime;

            _number++;

            NumberChanged?.Invoke();
        }
    }
}