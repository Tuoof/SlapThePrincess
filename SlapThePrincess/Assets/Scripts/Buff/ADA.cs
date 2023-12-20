using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADA : IBuffStrategy
{
    private float m_cooldown;
    public float Cooldown { get => m_cooldown; set => m_cooldown = value; }

    public void ApplyBuff(Monster monster)
    {
        Debug.Log($"Class Name: {GetType().Name} current cooldown {m_cooldown}");
        if (m_cooldown <= 0)
        {

        }
    }
}
