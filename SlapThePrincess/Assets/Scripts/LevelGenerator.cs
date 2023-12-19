using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform LevelPart;
    [SerializeField] private Transform endSpawnLevel;
    private Vector3 lastEndPosition;

    private void Awake()
    {
        lastEndPosition = endSpawnLevel.position;
        SpawnLevelPart();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnLevelPart()
    {
        Transform lastLevelPartTransform = SpawnLevelPart(lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndSpawnLevel").position;
    }

    private Transform SpawnLevelPart(Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(LevelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
}
