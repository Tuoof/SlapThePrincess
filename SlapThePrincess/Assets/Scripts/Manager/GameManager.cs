using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState { Idle, Battle , GameOver}
    public Event StartBattle;


    [SerializeField] PlayerController playerController;
    [SerializeField] BattleManager battleManager;
    [SerializeField] BuffInputManager buffInputManager;
    [SerializeField] Camera mainCamera;

    [SerializeField] GameObject HiddenUiOver;
    [SerializeField] GameObject WinnerUi;

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

    public void EnterBattle(int monsterIndex)
    {
        state = GameState.Battle;
        playerController.SetCanPlayerMove(false);

        battleManager.gameObject.SetActive(true);
        battleManager.InitBattle(monsterIndex);

        mainCamera.gameObject.SetActive(false);
    }

    public void ExitBattle()
    {
        state = GameState.Idle;
        playerController.SetCanPlayerMove(true);

        buffInputManager.ResetImage();
        battleManager.gameObject.SetActive(false);

        mainCamera.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        HiddenUiOver.SetActive(false);
        WinnerUi.SetActive(true);
    }
}
