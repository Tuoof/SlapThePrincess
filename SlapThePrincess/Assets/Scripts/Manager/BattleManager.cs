using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private MonsterSO m_myMonsterSO;
    [SerializeField] private List<MonsterSO> m_enemiesSO;

    [SerializeField]
    private Monster m_myMonster;
    [SerializeField]
    private Monster m_enemy;

    private Coroutine m_myMonsterAttack;
    private Coroutine m_enemyAttack;


    private void Start()
    {
        InitBattle();
    }

    private void InitBattle()
    {
        m_myMonster.ReInitMonster(m_myMonsterSO);
        m_myMonsterAttack = StartCoroutine(MonsterAttackCoroutine(m_myMonster, m_enemy));

        //you can tweak this thing, to follow the enemy type
        m_enemy.ReInitMonster(m_enemiesSO[0]);
        m_enemyAttack =  StartCoroutine(MonsterAttackCoroutine(m_enemy, m_myMonster));
    }

    private IEnumerator MonsterAttackCoroutine(Monster attacker, Monster target)
    {
        yield return new WaitForSeconds(attacker.GetMyAttackSpeed());
        Debug.Log($"{attacker} Attack {target}");
        if(target.GetMyCurrentHP() > 0)
        {
            // Perform the attack
            attacker.PerformAttack(target);
            if (target.GetMyCurrentHP() > 0 && attacker.GetMyCurrentHP() > 0)
            {
                StartCoroutine(MonsterAttackCoroutine(attacker, target));
            }
            else
            {
                Debug.Log("Battle Ended!");
            }
        }
        yield return null;
    }
}
