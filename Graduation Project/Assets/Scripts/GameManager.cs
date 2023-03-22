using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState GameState;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ChangeState(GameState.GenerateGrid);
    }

    public void ChangeState(GameState newState)
    {
        GameState = newState;
        switch (newState)
        {
            case GameState.GenerateGrid:
                GridManager.Instance.GenerateGrid();
                MenuManager.Instance.UpdateCurrencyDisplay();
                break;
            case GameState.SpawnHeros:
                UnitManager.Instance.SpawnHeros();
                break;
            case GameState.SpawnEnemies:
                UnitManager.Instance.SpawnEnemies();
                break;
            case GameState.HerosTurn:
                break;
            case GameState.EnemiesTurn:
                UnitManager.Instance.EnemyMoves();
                break;
            case GameState.BattleLost:
                CurrencyManager.cheese = 0;
                CurrencyManager.UpdateCheese();
                MenuManager.Instance.UpdateCurrencyDisplay();
                MenuManager.Instance.ShowBattleLostScreen();
                break;
            case GameState.BattleWon:
                CurrencyManager.cheese += 5;
                CurrencyManager.UpdateCheese();
                MenuManager.Instance.UpdateCurrencyDisplay();
                MenuManager.Instance.ShowBattleWonScreen();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }
}

public enum GameState
{
    GenerateGrid = 0,
    SpawnHeros = 1,
    SpawnEnemies = 2,
    HerosTurn = 3,
    EnemiesTurn = 4,
    BattleLost = 5,
    BattleWon = 6
}
