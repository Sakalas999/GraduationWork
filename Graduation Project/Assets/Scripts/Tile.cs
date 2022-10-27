using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public string TileName;
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight, _available;

    public BaseUnit occupiedUnit;
    public bool walkable => occupiedUnit == null;

    public void Init(bool isOffset)
    {
        if (isOffset)
        {
            _renderer.color = _offsetColor;
        }
        else
        {
            _renderer.color = _baseColor;
        }
    }

    void OnMouseEnter()
    {
        if (GameManager.Instance.GameState == GameState.BattleWon || GameManager.Instance.GameState == GameState.BattleLost) return;
            _highlight.SetActive(true);
            MenuManager.Instance.ShowTileInfo(this);

        if (occupiedUnit != null)
        {
            UnitManager.Instance.HoveringOverACharacter(true);
            UnitManager.Instance.GetAvailableTiles(this);
        }
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);
        MenuManager.Instance.ShowTileInfo(null);

        if (occupiedUnit != null)
        {
            UnitManager.Instance.HoveringOverACharacter(false);
            UnitManager.Instance.GetAvailableTiles(this);
        }
    }

    void OnMouseDown()
    {
        if (GameManager.Instance.GameState != GameState.HerosTurn) return;

        if (occupiedUnit != null)
        {
            if (occupiedUnit.Faction == Faction.Hero)
            {
                UnitManager.Instance.SetSelectedHero((BaseHero)occupiedUnit);
                UnitManager.Instance.GetAvailableTiles(this);
            }
            else
            {
                if (UnitManager.Instance.SelectedHero != null && DistanceX(this) <= 2 && DistanceY(this) <= 2 && DistanceY(this) + DistanceX(this) <= 2)
                {
                    var enemy = (BaseEnemy)occupiedUnit;
                    Destroy(enemy.gameObject);
                    SetUnit(UnitManager.Instance.SelectedHero);
                    UnitManager.Instance.SetSelectedHero(null);
                    UnitManager.Instance.GetAvailableTiles(UnitManager.Instance.HerosTile);
                    UnitManager.Instance.SetHerosTile(this);
                    UnitManager.Instance.SetEnemiesTile(null);
                    if (UnitManager.Instance.EnemiesTile != null)
                    {
                        GameManager.Instance.ChangeState(GameState.EnemiesTurn);
                    }
                    else
                    {
                        GameManager.Instance.ChangeState(GameState.BattleWon);
                    }
                }
            }
        }
        else
        {
            if (UnitManager.Instance.SelectedHero != null && DistanceX(this) <= 2 && DistanceY(this) <= 2 && DistanceY(this) + DistanceX(this) <= 2)
            {
                SetUnit(UnitManager.Instance.SelectedHero);
                UnitManager.Instance.SetSelectedHero(null);
                UnitManager.Instance.GetAvailableTiles(UnitManager.Instance.HerosTile);
                UnitManager.Instance.SetHerosTile(this);
                GameManager.Instance.ChangeState(GameState.EnemiesTurn);

            }
        }

    }

    public void SetUnit (BaseUnit unit)
    {
        if (unit.occupiedTile != null) unit.occupiedTile.occupiedUnit = null;
        unit.transform.position = transform.position;
        occupiedUnit = unit;
        unit.occupiedTile = this;
    }

    public float DistanceX(Tile tile)
    {
        return Mathf.Abs(UnitManager.Instance.HerosTile.transform.position.x - tile.transform.position.x);
    }

    public float DistanceY(Tile tile)
    {
        return Mathf.Abs(UnitManager.Instance.HerosTile.transform.position.y - tile.transform.position.y);
    }

    public void ShowAvailableTiles()
    {
        _available.SetActive(true);
    }

    public void DisablleAvailableTiles()
    {
        _available.SetActive(false);
    }
}