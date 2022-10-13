using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [SerializeField] private GameObject _selectedHeroObject, _tileObject, _tileUnitObject, _battleLostObject, _battleWonObject;

    void Awake()
    {
        Instance = this;
    }

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

    public void ShowSelectedHero(BaseHero hero)
    {
        if (hero == null ^ GameManager.Instance.GameState == GameState.BattleLost ^ GameManager.Instance.GameState == GameState.BattleWon)
        {
            _selectedHeroObject.SetActive(false);
            return;
        }

        _selectedHeroObject.GetComponentInChildren<TextMeshProUGUI>().text = hero.UnitName;
        _selectedHeroObject.SetActive(true);
    }

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
}