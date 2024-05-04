using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SmoothHealthbar : Healthbar
{
    [SerializeField] private float _changeTime;

    private Coroutine _coroutine;
    protected Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    protected override void Display(float currentHealth)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(SmoothDisplaing(currentHealth));
    }

    private IEnumerator SmoothDisplaing(float currentHealth)
    {
        float startValue = _slider.value;
        float timeGone = 0f;

        while (timeGone <= _changeTime)
        {
            timeGone += Time.deltaTime;

            _slider.value = Mathf.Lerp(startValue, currentHealth / _maxHealth, timeGone / _changeTime);
            yield return null;
        }
    }
}
