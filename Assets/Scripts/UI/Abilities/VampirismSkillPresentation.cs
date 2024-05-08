using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VampirismSkillPresentation : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _secondsIndicator;

    private Coroutine _cooldown;

    private void Start()
    {
        DisplayAbilityStill();
    }

    public void DisplayAbilityCooldown(float cooldown)
    {
        _icon.color = Color.gray;

        _cooldown = StartCoroutine(DisplayCooldown(cooldown));
    }

    private void DisplayAbilityStill()
    {
        if(_cooldown != null)
        {
            StopCoroutine(_cooldown);

            _cooldown = null;
        }

        _icon.color = Color.white;
        _secondsIndicator.text = "[Z]";
    }

    private IEnumerator DisplayCooldown(float cooldown)
    {
        WaitForSeconds oneSecond = new WaitForSeconds(1f);

        for(float i = cooldown; i > 0f; i--)
        {
            _secondsIndicator.text = i.ToString();

            yield return oneSecond;
        }

        DisplayAbilityStill();
    }
}
