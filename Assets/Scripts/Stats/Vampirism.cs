using System.Collections;
using UnityEngine;

[RequireComponent(typeof(VampirismAura))]
[RequireComponent(typeof(SpriteRenderer))]
public class Vampirism : MonoBehaviour
{
    [SerializeField] private float _activatedTime;
    [SerializeField] private float _cooldown;
    [SerializeField] private float _amount;
    [SerializeField] private Player _player;
    [SerializeField] private VampirismSkillPresentation _skillPresentation;

    private Characteristics _characteristics;
    private VampirismAura _vampirismAura;

    private Coroutine _abilityCooldown;
    private Coroutine _enableVampirism;

    private void Awake()
    {
        _characteristics = _player.GetComponent<Characteristics>();
        _vampirismAura = GetComponent<VampirismAura>();
    }

    private void OnEnable ()
    {
        _player.OnVampirismEnable += ActivateAbility;
    }

    private void OnDisable()
    {
        _player.OnVampirismEnable -= ActivateAbility;
    }

    private void ActivateAbility()
    {
        if(_enableVampirism == null && _abilityCooldown == null)
        {
            _enableVampirism = StartCoroutine(EnableVampirism());
            _abilityCooldown = StartCoroutine(AbilityCooldown(_cooldown));

            _skillPresentation.DisplayAbilityCooldown(_cooldown);
        }
    }

    private void LifeSteal(Characteristics enemy)
    {
        enemy.TakeDamage(_amount);
        _characteristics.Heal(_amount);
    }

    private void EndVampirism()
    {
        if(_enableVampirism != null)
        {
            _vampirismAura.Deactivate();

            StopCoroutine(_enableVampirism);
            _enableVampirism = null;
        }
    }

    private void EndCooldown()
    {
        if (_abilityCooldown != null)
        {
            StopCoroutine(_abilityCooldown);
            _abilityCooldown = null;
        }
    }

    private IEnumerator EnableVampirism()
    {
        float lifestealCooldown = 1f;

        float currentTime = 0f;
        float currentLifestealTime = 0f;

        _vampirismAura.Activate();

        while (currentTime < _activatedTime)
        {
            if(currentLifestealTime >= lifestealCooldown)
            {
                currentLifestealTime = 0;

                foreach(Characteristics enemy in _vampirismAura.Affected)
                {
                    LifeSteal(enemy);
                }
            }

            currentTime += Time.deltaTime;
            currentLifestealTime += Time.deltaTime;

            yield return null;
        }

        EndVampirism();
    }

    private IEnumerator AbilityCooldown(float cooldown)
    {
        WaitForSeconds waitForCooldown = new WaitForSeconds(cooldown);

        yield return waitForCooldown;

        EndCooldown();
    }
}
