using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Monster", menuName = "STP/Monster", order = 0)]
public class MonsterSO : ScriptableObject
{
    [SerializeField]
    public string Name;
    [SerializeField]
    public int Power;
    [SerializeField]
    public int HP;
    [SerializeField]
    public int MaxHP;
    [SerializeField]
    public int Armor;
    [SerializeField]
    public float AttackSpeed;
}
