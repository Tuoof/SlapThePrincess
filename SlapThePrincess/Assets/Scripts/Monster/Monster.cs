using UnityEngine;

public class Monster: MonoBehaviour
{
    private string m_name;
    private int m_power;
    private int m_hp;
    private int m_maxHp;
    private int m_armor;
    private float m_attackSpeed;

    public void ReInitMonster(MonsterSO data)
    {
        m_name = data.Name;
        m_power = data.Power;
        m_hp = data.HP;
        m_maxHp = data.MaxHP;
        m_armor = data.Armor;
        m_attackSpeed = data.AttackSpeed;
    }

    #region combat
    public int GetMyCurrentHP()
    {
        return m_hp;
    }

    public void PerformAttack(Monster target)
    {
        float damage = CalculateDamage(target);
        target.ModifyHP(-(int)damage);
        Debug.Log($"{m_name} attacks {target.m_name} for {damage} damage. {target.m_name}'s HP: {target.GetMyCurrentHP()}");
    }

    public float GetMyAttackSpeed()
    {
        return m_attackSpeed;
    }

    private float CalculateDamage(Monster target)
    {
        float baseDamage = m_power;
        float netDamage = Mathf.Max(baseDamage - target.m_armor, 0);
        return netDamage;
    }

    #endregion

    #region buff
    public void ModifyMaxHP(int modifier)
    {
        Debug.Log($"modify max HP from {m_maxHp} to {m_maxHp + modifier}");
        if(m_maxHp == m_hp)
        {
            m_maxHp += modifier;
            m_hp = m_maxHp;
        }
        else
        {
            m_hp += modifier;
            if(m_hp > m_maxHp)
            {
                m_maxHp = m_hp;
            }
        }
    }

    public void ModifyArmor(int modifier)
    {
        Debug.Log($"modify Armor from {m_armor} to {m_armor + modifier}");
        m_armor += modifier;
    }

    public void ModifyPower(int modifier)
    {
        Debug.Log($"modify Power from {m_power} to {m_power + modifier}");
        m_power += modifier;
    }

    public void ModifyHP(int modifier)
    {
        if(m_hp + modifier < m_maxHp)
        {
            Debug.Log($"modify HP from {m_hp} to {m_hp + modifier}");
            m_hp += modifier;
        }
    }

    public void ModifyAttackSpeed(float modifier)
    {
        float val = m_attackSpeed * modifier;
        Debug.Log($"modify AttackSpeed from {m_attackSpeed} to {m_attackSpeed + val}");
        m_attackSpeed += val;
    }

    #endregion
}
