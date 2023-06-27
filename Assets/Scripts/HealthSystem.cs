using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float m_maxHealth;
    private float m_currentHealth;

    public event Action<float> OnEntityHeal;
    public float MaxHealth()
    {
        return m_maxHealth;
    }
    public float getCurrentHealth()
    {
        return m_currentHealth;
    }

    public void Init()
    {
        m_currentHealth = m_maxHealth;
        OnEntityHeal = GetHeal;
    }

    public void GetHeal(float p_healAmount)
    {
        m_currentHealth += p_healAmount;

        if (m_currentHealth >= m_maxHealth)
        {
            m_currentHealth = m_maxHealth;
        }

    }

    public void Test()
    {
        OnEntityHeal?.Invoke(10);
    }
}
