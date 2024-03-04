using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static Public_Enum;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float healthChangeDelay = .5f;

    private CharacterStatsHandler _statsHandler;
    private float _timeSinceLastChange = float.MaxValue;

    public event Action OnDamage;
    public event Action OnHeal;
    public event Action OnDeath;
    public event Action OnInvincibilityEnd;

    public float CurrentHealth { get; private set; }

    public float MaxHealth => _statsHandler.CurrentStats.maxHealth;

    private void Awake()
    {
        _statsHandler = GetComponent<CharacterStatsHandler>();
        OverallManager.Instance.UiManager.HpText.text = "체력: " +  (CurrentHealth.ToString() + "/" + MaxHealth.ToString());
    }

    private void Start()
    {
        CurrentHealth = _statsHandler.CurrentStats.maxHealth;
    }

    private void Update()
    {
        if (_timeSinceLastChange < healthChangeDelay)
        {
            _timeSinceLastChange += Time.deltaTime;
            if (_timeSinceLastChange >= healthChangeDelay)
            {
                OnInvincibilityEnd?.Invoke();
            }
        }
    }

    public bool ChangeHealth(float change)
    {
        OverallManager.Instance.UiManager.HpText.text = "체력: " + (CurrentHealth.ToString() + "/" + MaxHealth.ToString());
        if (change == 0 || _timeSinceLastChange < healthChangeDelay)
        {
            return false;
        }

        _timeSinceLastChange = 0f;
        CurrentHealth += change;
        CurrentHealth = CurrentHealth > MaxHealth ? MaxHealth : CurrentHealth;
        CurrentHealth = CurrentHealth < 0 ? 0 : CurrentHealth;

        if (change > 0)
        {
            OnHeal?.Invoke();
        }
        else
        {
            OnDamage?.Invoke();
        }

        if (CurrentHealth <= 0f)
        {
            OverallManager.Instance.GameDataManager.Ending(Ending_type.GameOver);
            //CallDeath();
        }

        return true;
    }

    private void CallDeath()
    {
        OnDeath?.Invoke();
    }
}