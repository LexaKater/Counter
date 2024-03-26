using System.Collections;
using TMPro;
using UnityEngine;

public class Сounter : MonoBehaviour
{
    [SerializeField] private TextMeshPro _text;

    private float _delay = 0.5f;
    private float _number = 0;
    private bool _isCoroutineWork = false;

    private void Update()
    {
        ToggleCoroutine();
    }

    private IEnumerator IncreaseNumber()
    {
        var wait = new WaitForSeconds(_delay);

        while (_isCoroutineWork)
        {
            _number++;
            ShowText();

            yield return wait;
        }
    }

    private void ToggleCoroutine()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isCoroutineWork == false)
            {
                _isCoroutineWork = true;
                StartCoroutine(IncreaseNumber());
            }
            else
            {
                _isCoroutineWork = false;
                StopCoroutine(IncreaseNumber());
            }
        }
    }

    private void ShowText() => _text.text = _number.ToString();
}
