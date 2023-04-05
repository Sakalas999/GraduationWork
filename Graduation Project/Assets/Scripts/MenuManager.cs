using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [SerializeField] private GameObject _selectedHeroObject, _tileObject, _tileUnitObject, _battleLostObject, _battleWonObject, _attackButton, _currencyDisplay;

    void Awake()
    {
        Instance = this;
    }

    //Shows tile name
    public void ShowTileInfo(Tile tile)
    {

        if (tile == null || GameManager.Instance.GameState == GameState.BattleLost || GameManager.Instance.GameState == GameState.BattleWon)
        {
            _tileObject.SetActive(false);
            _tileUnitObject.SetActive(false);
            return;
        }

        _tileObject.GetComponentInChildren<TextMeshProUGUI>().text = tile.TileName;
        _tileObject.SetActive(true);

        if (tile.occupiedUnit)
        {
            _tileUnitObject.GetComponentInChildren<TextMeshProUGUI>().text = tile.occupiedUnit.UnitName;
            _tileUnitObject.SetActive(true);
        }
    }

    //Shows selected hero's name
    public void ShowSelectedHero(BaseHero hero)
    {
        if (hero == null || GameManager.Instance.GameState == GameState.BattleLost || GameManager.Instance.GameState == GameState.BattleWon)
        {
            _selectedHeroObject.SetActive(false);
            return;
        }

        _selectedHeroObject.GetComponentInChildren<TextMeshProUGUI>().text = hero.UnitName;
        _selectedHeroObject.SetActive(true);
    }

    //Shows a battle lost scene
    public void ShowBattleLostScreen()
    {
        if (GameManager.Instance.GameState != GameState.BattleLost)
        {
            _battleLostObject.SetActive(false);
            return;
        }

        _battleLostObject.SetActive(true);
        _tileObject.SetActive(false);
        _tileUnitObject.SetActive(false);
        _selectedHeroObject.SetActive(false);
    }

    //Shows a battle won scene
    public void ShowBattleWonScreen()
    {
        if (GameManager.Instance.GameState != GameState.BattleWon)
        {
            _battleWonObject.SetActive(false);
            return;
        }

        _battleWonObject.SetActive(true);
        _tileObject.SetActive(false);
        _tileUnitObject.SetActive(false);
        _selectedHeroObject.SetActive(false);
    }

    //Displays Currency
    public void UpdateCurrencyDisplay()
    {
        TextMeshProUGUI text = _currencyDisplay.GetComponent<TextMeshProUGUI>();
        string[] temp = text.text.Split(' ');
        text.text = temp[0] + " " + CurrencyManager.cheese;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}