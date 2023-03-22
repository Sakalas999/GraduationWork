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
            UnitManager.Instance.GetAvailableTiles(this, true);
        }
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);
        MenuManager.Instance.ShowTileInfo(null);

        if (occupiedUnit != null)
        {
            if (occupiedUnit.Faction == Faction.Hero && UnitManager.Instance.SelectedHero != null) return;
            else
            {


                UnitManager.Instance.GetAvailableTiles(this, false);
            }
        }
    }

    void OnMouseDown()
    {
        if (GameManager.Instance.GameState != GameState.HerosTurn) return;

        if (occupiedUnit != null)
        {
            if (occupiedUnit.Faction == Faction.Hero)
            {
                UnitManager.Instance.SetSelectedHero((BaseHero)occupiedUnit, this);
                UnitManager.Instance.GetAvailableTiles(this, true);
            }
            else
            {
                if (UnitManager.Instance.SelectedHero != null && DistanceX(this) <= 2 && DistanceY(this) <= 2 && DistanceY(this) + DistanceX(this) <= 2
                    && !UnitManager.Instance.MovedHeroUnits[UnitManager.Instance.SelectedHeroIndex])
                {
                    var enemy = (BaseEnemy)occupiedUnit;
                    int index = 0;
                    occupiedUnit.TakeDamage();

                    if (occupiedUnit.Health <= 0)
                    {
                        for (int i = 0; i < UnitManager.Instance.EnemyAmount; i++)
                        {
                            if( UnitManager.Instance.EnemiesTile[i] != null &&this.name == UnitManager.Instance.EnemiesTile[i].name)
                            {
                                index = i;
                            }
                        }

                        Destroy(enemy.gameObject);
                        SetUnit(UnitManager.Instance.SelectedHero);
                        UnitManager.Instance.UpdateEnemyUnitAmount(-1);

                        UnitManager.Instance.GetAvailableTiles(UnitManager.Instance.HerosTile[UnitManager.Instance.SelectedHeroIndex], false);
                        UnitManager.Instance.SetHerosTile(this, UnitManager.Instance.SelectedHeroIndex);                       
                        UnitManager.Instance.SetSelectedHero(null, null);
                        UnitManager.Instance.SetEnemiesTile(null, index);
                        UnitManager.Instance.Enemy[index] = null;
                     }

                    UnitManager.Instance.UpdateHeroMovementAvailability(UnitManager.Instance.SelectedHeroIndex, true);
                    UnitManager.Instance.GetAvailableTiles(UnitManager.Instance.HerosTile[UnitManager.Instance.SelectedHeroIndex], false);
                     UnitManager.Instance.SetSelectedHero(null, null);

                    int countEnemies = 0;
                    for (int i = 0; i < UnitManager.Instance.EnemyAmount; i++)
                    {
                        if (UnitManager.Instance.EnemiesTile[i] != null)
                        {
                            countEnemies++;
                        }
                    }

                    int countHeros = 0;
                    for (int i = 0; i < UnitManager.Instance.HeroAmount; i++)
                    {
                        if (UnitManager.Instance.HerosTile[i] != null)
                        {
                            countHeros++;
                        }
                    }

                    int countMovedUnits = 0;
                    for (int i = 0; i < UnitManager.Instance.HeroAmount; i++)
                    {
                        if(UnitManager.Instance.MovedHeroUnits[i])
                        {
                            countMovedUnits++;
                        }
                    }

                    if (countEnemies != 0 && (countMovedUnits == UnitManager.Instance.HeroAmount || countMovedUnits == countHeros))
                    {
                        GameManager.Instance.ChangeState(GameState.EnemiesTurn);
                        for (int i = 0; i < UnitManager.Instance.EnemyAmount; i++)
                        {
                            UnitManager.Instance.UpdateEnemyMovementAvailability(i, false);
                        }
                    }
                    if (countEnemies == 0)
                    {
                        GameManager.Instance.ChangeState(GameState.BattleWon);
                    }
                }
            }
        }
        else
        {
            if (UnitManager.Instance.SelectedHero != null && DistanceX(this) <= 2 && DistanceY(this) <= 2 && DistanceY(this) + DistanceX(this) <= 2
                && !UnitManager.Instance.MovedHeroUnits[UnitManager.Instance.SelectedHeroIndex])
            {
                SetUnit(UnitManager.Instance.SelectedHero);
                UnitManager.Instance.GetAvailableTiles(UnitManager.Instance.HerosTile[UnitManager.Instance.SelectedHeroIndex], false);
                UnitManager.Instance.SetHerosTile(this, UnitManager.Instance.SelectedHeroIndex);
                UnitManager.Instance.UpdateHeroMovementAvailability(UnitManager.Instance.SelectedHeroIndex, true);
                UnitManager.Instance.SetSelectedHero(null, null);

                int countEnemies = 0;
                for (int i = 0; i < UnitManager.Instance.EnemyAmount; i++)
                {
                    if (UnitManager.Instance.EnemiesTile[i] != null)
                    {
                        countEnemies++;
                    }
                }

                int countHeros = 0;
                for (int i = 0; i < UnitManager.Instance.HeroAmount; i++)
                {
                    if (UnitManager.Instance.HerosTile[i] != null)
                    {
                        countHeros++;
                    }
                }

                int countMovedUnits = 0;
                for (int i = 0; i < UnitManager.Instance.HeroAmount; i++)
                {
                    if (UnitManager.Instance.MovedHeroUnits[i])
                    {
                        countMovedUnits++;
                    }
                }

                if (countEnemies != 0 && (countMovedUnits == UnitManager.Instance.HeroAmount || countMovedUnits == countHeros))
                {
                    GameManager.Instance.ChangeState(GameState.EnemiesTurn);
                    for (int i = 0; i < UnitManager.Instance.EnemyAmount; i++)
                    {
                        UnitManager.Instance.UpdateEnemyMovementAvailability(i, false);
                    }
                }
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
        return Mathf.Abs(UnitManager.Instance.HerosTile[UnitManager.Instance.SelectedHeroIndex].transform.position.x - tile.transform.position.x);
    }

    public float DistanceY(Tile tile)
    {
        return Mathf.Abs(UnitManager.Instance.HerosTile[UnitManager.Instance.SelectedHeroIndex].transform.position.y - tile.transform.position.y);
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