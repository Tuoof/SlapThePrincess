using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDestroyer : MonoBehaviour
{
   LevelGenerator levelGenerator;

    // Start is called before the first frame update
    void Start()
    {
        levelGenerator = GameObject.FindFirstObjectByType<LevelGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        levelGenerator.SpawnLevelPart();
        Destroy(gameObject, 2);

        Debug.Log("box collider Hit from" + other.name);
    }
}
