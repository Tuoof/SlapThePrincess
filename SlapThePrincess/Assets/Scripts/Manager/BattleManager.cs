using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] UIBar uiPlayerBar;
    [SerializeField] UIBar uiEnemyBar;

    [SerializeField] private MonsterSO m_myMonsterSO;
    [SerializeField] private List<MonsterSO> m_enemiesSO;

    [SerializeField] private Monster m_myMonster;
    [SerializeField] private Monster[] m_enemyPrefabs;
    [SerializeField] Transform EnemyLoc;
    private Monster m_enemy;

    private Animator m_myMonsterAnim;
    private Animator m_enemyAnim;

    private Coroutine m_myMonsterAttack;
    private Coroutine m_enemyAttack;

    private int getIndexMonster;

    private void Awake()
    {
        gameManager = GameObject.FindFirstObjectByType<GameManager>();
    }

    private void Start()
    {
        m_myMonster.InitMonster(m_myMonsterSO);
        
        SetHpUi();
        SetArmorUi();
        SetPowerUi();

        gameObject.SetActive(false);
    }

    private void InitPlayerMonster()
    {
        SetMonsterUnit();
        m_myMonster.ReInitMonster(m_myMonsterSO);
        m_myMonsterAttack = StartCoroutine(MonsterAttackCoroutine(m_myMonster, m_enemy));
    }
    private void InitEnemyMonster()
    {
        SetEnemyUnit();
        //you can tweak this thing, to follow the enemy type
        m_enemy.InitMonster(m_enemiesSO[getIndexMonster]);
        m_enemyAttack = StartCoroutine(MonsterAttackCoroutine(m_enemy, m_myMonster));
    }

    public void InitBattle(int monsterIndex)
    {
        getIndexMonster = monsterIndex;

        InitEnemyMonster();
        InitPlayerMonster();

        SetHpUi();
        SetArmorUi();
        SetPowerUi();
    }

    private IEnumerator MonsterAttackCoroutine(Monster attacker, Monster target)
    {
        yield return new WaitForSeconds(attacker.GetMyAttackSpeed());

        Debug.Log($"{attacker} Attack {target}");
        if (target.GetMyCurrentHP() > 0)
        {
            // Perform the attack
            attacker.PerformAttack(target);
            SetHpUi();

            if (target.GetMyCurrentHP() > 0 && attacker.GetMyCurrentHP() > 0)
            {
                StartCoroutine(MonsterAttackCoroutine(attacker, target));
            }
            else
            {
                if (target == m_enemy)
                {
                    StopAllCoroutines();
                    Destroy(m_enemy.gameObject);
                    gameManager.ExitBattle();
                }
                else
                {
                    StopAllCoroutines();
                    Debug.Log($"Game Over");
                }
            }
        }
        yield return null;
    }

    private void SetMonsterUnit()
    {
        m_myMonsterAnim = m_myMonster.GetComponent<Animator>();
    }

    public void SetEnemyUnit()
    {
        foreach (var item in m_enemyPrefabs)
        {
            if (item.monsterIndex == getIndexMonster)
            {
                m_enemy = Instantiate(item, EnemyLoc.position, Quaternion.identity, EnemyLoc.transform);
                m_enemyAnim = m_enemy.GetComponent<Animator>();
            }
        }
    }

    public void SetHpUi()
    {
        uiPlayerBar.SetHP((float)m_myMonster.GetMyCurrentHP() / m_myMonster.GetMyMaxtHP());
        if (m_enemy)
            uiEnemyBar.SetHP((float)m_enemy.GetMyCurrentHP() / m_enemy.GetMyMaxtHP());
    }

    public void SetArmorUi()
    {
        uiPlayerBar.SetArmor((float)m_myMonster.GetArmor() / 20f);
        if (m_enemy)
            uiEnemyBar.SetArmor((float)m_enemy.GetArmor() / 20f);
    }

    public void SetPowerUi()
    {
        uiPlayerBar.SetPower((float)m_myMonster.GetPower() / 20f);
        if (m_enemy)
            uiEnemyBar.SetPower((float)m_enemy.GetPower() / 20f);
    }
}
