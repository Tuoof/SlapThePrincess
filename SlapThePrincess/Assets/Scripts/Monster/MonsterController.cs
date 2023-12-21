using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    GameManager gameManager;
    public int monsterIndex;

    private void Awake()
    {
        gameManager = GameObject.FindFirstObjectByType<GameManager>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameManager.EnterBattle(monsterIndex);
            Destroy(this.gameObject);
        }
    }
}
