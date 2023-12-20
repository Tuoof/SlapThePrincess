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
        m_maxHp += modifier;
    }

    public void ModifyArmor(int modifier)
    {
        m_armor += modifier;
    }

    public void ModifyPower(int modifier)
    {
        m_power += modifier;
    }

    public void ModifyHP(int modifier)
    {
        m_hp += modifier;
    }

    public void ModifyAttackSpeed(float modifier)
    {
        float val = m_attackSpeed * modifier;
        m_attackSpeed += val;
    }

    #endregion
}
