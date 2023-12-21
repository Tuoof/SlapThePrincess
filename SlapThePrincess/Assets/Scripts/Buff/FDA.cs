using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FDA : IBuffStrategy
{
    private float m_cooldown;
    private float m_lastApplicationTime;

    public FDA(float cooldown)
    {
        Cooldown = cooldown;
    }

    public float Cooldown
    {
        get => m_cooldown;
        set => m_cooldown = Mathf.Max(0, value); // Ensure cooldown is non-negative
    }

    public void ApplyBuff(Monster monster)
    {
        float currentTime = Time.time;

        if (currentTime - m_lastApplicationTime >= m_cooldown)
        {
            Debug.Log($"Class Name: {GetType().Name} applying buff!");

            // Perform your buff logic here
            monster.ModifyPower(1);
            monster.ModifyHP(2);
            monster.ModifyAttackSpeed(0.3f);

            // Update the last application time
            m_lastApplicationTime = currentTime;
        }
        else
        {
            Debug.Log($"Class Name: {GetType().Name} on cooldown. Remaining time: {m_cooldown - (currentTime - m_lastApplicationTime)}");
        }
    }
}
