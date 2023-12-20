using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState { Idle, Battle }

    [SerializeField] PlayerController playerController;
    [SerializeField] BattleManager battleManager;
    [SerializeField] Camera mainCamera;

    GameState state;

    private void Awake()
    {
        playerController = GameObject.FindFirstObjectByType<PlayerController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        state = GameState.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterBattle()
    {
        state = GameState.Battle;
        playerController.SetCanPlayerMove(false);
        battleManager.gameObject.SetActive(true);
        mainCamera.gameObject.SetActive(false);

        Invoke("ExitBattle", 5);
    }

    public void ExitBattle()
    {
        state = GameState.Idle;
        playerController.SetCanPlayerMove(true);
        battleManager.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);

    }
}
