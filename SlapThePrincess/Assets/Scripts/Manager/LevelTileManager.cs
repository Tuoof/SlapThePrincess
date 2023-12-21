using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTileManager : MonoBehaviour
{
    LevelGenerator levelGenerator;
    Transform[] monsterSpawnComponents;

    public Transform spawnLoc;
    public GameObject[] monsterPrefab;

    private void Awake()
    {
        levelGenerator = GameObject.FindFirstObjectByType<LevelGenerator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnMonster();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        levelGenerator.SpawnLevelPart();
        Destroy(gameObject, 2);
    }

    void SpawnMonster()
    {
        monsterSpawnComponents = spawnLoc.GetComponentsInChildren<Transform>();

        foreach (var item in monsterSpawnComponents)
        {
            // choose random point to spawn monster
            int MonsterSpawnIndex = Random.Range(0, monsterPrefab.Length);
            Instantiate(monsterPrefab[MonsterSpawnIndex], item.position, Quaternion.identity, item.transform);
        }
        
    }
}
