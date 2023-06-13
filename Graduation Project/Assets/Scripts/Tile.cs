using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public string TileName;
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight, _available, _unmoved;

    public BaseUnit occupiedUnit;
    public bool walkable => occupiedUnit == null;

    //assigns a colour to a tile depending whether or not is it offset
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

    //Method for when the player hovers the mouse over a specific tile and depending on what's on it displays all the appropriate information
    void OnMouseEnter()
    {
        //Displays tile's name when hovered over
        if (GameManager.Instance.GameState == GameState.BattleWon || GameManager.Instance.GameState == GameState.BattleLost) return;

        //Displays the hovered over character's tile that it can move to
            _highlight.SetActive(true);
            MenuManager.Instance.ShowTileInfo(this);

        //Displays occupied unit's name when hovered over
        if (occupiedUnit != null)
        {
            if (UnitManager.Instance.SelectedHero != null && (BaseHero)occupiedUnit == UnitManager.Instance.SelectedHero)
            {
                UnitManager.Instance.GetAvailableTiles(occupiedUnit, this, true);
            }
            else if (UnitManager.Instance.SelectedHero == null)
            {
                UnitManager.Instance.GetAvailableTiles(occupiedUnit, this, true);
            
            }
        }
    }

    //Method for when the player's mouse leaves the hovered over tile
    void OnMouseExit()
    {
        //Hides the available tiles of a character
        _highlight.SetActive(false);
        MenuManager.Instance.ShowTileInfo(null);

        //this is for selected character to still show the available tiles when the mouse leaves it's area
        if (occupiedUnit != null)
        {
            if (UnitManager.Instance.SelectedHero != null) return;
            else
            {


                UnitManager.Instance.GetAvailableTiles(occupiedUnit, this, false);
            }
        }
    }

    //Method for when a player is using mouse to move and attack characters
    void OnMouseDown()
    {
        if (GameManager.Instance.GameState != GameState.HerosTurn) return;

        if (occupiedUnit != null)
        {
            //We get the selected hero character that later on can perform actions
            if (occupiedUnit.Faction == Faction.Hero)
            {
                UnitManager.Instance.SetSelectedHero((BaseHero)occupiedUnit, this);
                UnitManager.Instance.GetAvailableTiles(occupiedUnit, this, true);
            }
            else
            {
                //Attacking enemy units
                if (UnitManager.Instance.SelectedHero != null && DistanceX(this) <= 1 && DistanceY(this) <= 1
                    && !UnitManager.Instance.MovedHeroUnits[UnitManager.Instance.SelectedHeroIndex])
                {
                    var enemy = (BaseEnemy)occupiedUnit;
                    int index = 0;
                    float debuff;

                    if (UnitManager.Instance.SelectedHero.isWounded)
                    {
                        debuff = 0.5f;
                    }
                    else
                    {
                        debuff = 1;
                    }

                    if (UnitManager.Instance.SelectedHero.Type == Type.Hero1 || UnitManager.Instance.SelectedHero.Type == Type.Hero3 
                        || UnitManager.Instance.SelectedHero.Type == Type.Hero5)
                    {
                        float damage = (10 + PlayerPrefs.GetInt("DamageEffectsAll")) * PlayerPrefs.GetFloat("DamageEffectsH1");
                        Debug.Log("Damage " + damage);
                        occupiedUnit.TakeDamage(damage * debuff);
                        AudioManager.Instance.Play("Attack");
                    }

                    if (UnitManager.Instance.SelectedHero.Type == Type.Hero2 || UnitManager.Instance.SelectedHero.Type == Type.Hero4)
                    {
                        float damage = (20 + PlayerPrefs.GetInt("DamageEffectsAll")) * PlayerPrefs.GetFloat("DamageEffectsH2");
                        occupiedUnit.TakeDamage( damage *  debuff);
                        AudioManager.Instance.Play("Attack");
                    }

                    //Destroys an enemy unit if it reaches 0 or less health
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
                        UnitManager.Instance.GetAvailableTiles(UnitManager.Instance.HerosTile[UnitManager.Instance.SelectedHeroIndex].occupiedUnit,
                            UnitManager.Instance.HerosTile[UnitManager.Instance.SelectedHeroIndex], false);
                        SetUnit(UnitManager.Instance.SelectedHero);
                        UnitManager.Instance.UpdateEnemyUnitAmount(-1);                        
                        UnitManager.Instance.SetHerosTile(this, UnitManager.Instance.SelectedHeroIndex);                       
                        UnitManager.Instance.SetSelectedHero(null, null);
                        UnitManager.Instance.SetEnemiesTile(null, index);
                        UnitManager.Instance.Enemy[index] = null;
                     }

                    UnitManager.Instance.UpdateHeroMovementAvailability(UnitManager.Instance.SelectedHeroIndex, true);
                    UnitManager.Instance.GetAvailableTiles(UnitManager.Instance.HerosTile[UnitManager.Instance.SelectedHeroIndex].occupiedUnit, 
                        UnitManager.Instance.HerosTile[UnitManager.Instance.SelectedHeroIndex], false);
                     UnitManager.Instance.SetSelectedHero(null, null);

                    //Counts how many enemies are left on the grid
                    int countEnemies = 0;
                    for (int i = 0; i < UnitManager.Instance.EnemyAmount; i++)
                    {
                        if (UnitManager.Instance.EnemiesTile[i] != null)
                        {
                            countEnemies++;
                        }
                    }

                    //Counts how many hero units are left on the grid
                    int countHeros = 0;
                    for (int i = 0; i < UnitManager.Instance.HeroAmount; i++)
                    {
                        if (UnitManager.Instance.HerosTile[i] != null)
                        {
                            countHeros++;
                        }
                    }

                    //Counts moved hero units
                    int countMovedUnits = 0;
                    for (int i = 0; i < UnitManager.Instance.HeroAmount; i++)
                    {
                        if(UnitManager.Instance.MovedHeroUnits[i])
                        {
                            countMovedUnits++;
                        }
                    }

                    //Changes game state and resets the enemies moves
                    if (countEnemies != 0 && (countMovedUnits == UnitManager.Instance.HeroAmount || countMovedUnits == countHeros))
                    {
                        GameManager.Instance.ChangeState(GameState.EnemiesTurn);
                        for (int i = 0; i < UnitManager.Instance.EnemyAmount; i++)
                        {
                            UnitManager.Instance.UpdateEnemyMovementAvailability(i, false);
                        }
                    }

                    //Ends battle if no enemies are left on the grid
                    if (countEnemies == 0)
                    {
                        GameManager.Instance.ChangeState(GameState.BattleWon);
                    }
                }
            }
        }
        else
        {
            //Moves hero unit to a new tile
            if (UnitManager.Instance.SelectedHero != null && 
                UnitManager.Instance.SelectedHero.CanItMove(UnitManager.Instance.HerosTile[UnitManager.Instance.SelectedHeroIndex], this, UnitManager.Instance.SelectedHero.Type)
                && !UnitManager.Instance.MovedHeroUnits[UnitManager.Instance.SelectedHeroIndex])
            {         
                UnitManager.Instance.GetAvailableTiles(UnitManager.Instance.HerosTile[UnitManager.Instance.SelectedHeroIndex].occupiedUnit,
                    UnitManager.Instance.HerosTile[UnitManager.Instance.SelectedHeroIndex], false);
                SetUnit(UnitManager.Instance.SelectedHero);
                UnitManager.Instance.SetHerosTile(this, UnitManager.Instance.SelectedHeroIndex);
                UnitManager.Instance.UpdateHeroMovementAvailability(UnitManager.Instance.SelectedHeroIndex, true);
                UnitManager.Instance.SetSelectedHero(null, null);

                //Counts how many enemies are left on the grid
                int countEnemies = 0;
                for (int i = 0; i < UnitManager.Instance.EnemyAmount; i++)
                {
                    if (UnitManager.Instance.EnemiesTile[i] != null)
                    {
                        countEnemies++;
                    }
                }

                //Counts how many hero units are left on the grid
                int countHeros = 0;
                for (int i = 0; i < UnitManager.Instance.HeroAmount; i++)
                {
                    if (UnitManager.Instance.HerosTile[i] != null)
                    {
                        countHeros++;
                    }
                }

                //Counts moved hero units
                int countMovedUnits = 0;
                for (int i = 0; i < UnitManager.Instance.HeroAmount; i++)
                {
                    if (UnitManager.Instance.MovedHeroUnits[i])
                    {
                        countMovedUnits++;
                    }
                }

                //Ends battle if no enemies are left on the grid
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

    //Method to move a character to another tile
    public void SetUnit (BaseUnit unit)
    {
        if (unit.occupiedTile != null) unit.occupiedTile.occupiedUnit = null;
        unit.transform.position = transform.position;
        occupiedUnit = unit;
        unit.occupiedTile = this;
    }

    //Returns a distance bettween the selected hero's tile and the clicked on tile on x axis
    public float DistanceX(Tile tile)
    {
        return Mathf.Abs(UnitManager.Instance.HerosTile[UnitManager.Instance.SelectedHeroIndex].transform.position.x - tile.transform.position.x);
    }

    //Returns a distance bettween the selected hero's tile and the clicked on tile on y axis
    public float DistanceY(Tile tile)
    {
        return Mathf.Abs(UnitManager.Instance.HerosTile[UnitManager.Instance.SelectedHeroIndex].transform.position.y - tile.transform.position.y);
    }

    //Changes a tiles colour to available tile's colour
    public void ShowAvailableTiles()
    {
        _available.SetActive(true);
    }

    //Resets tile's colour to it's original colour
    public void DisablleAvailableTiles()
    {
        _available.SetActive(false);
    }

    public void ShowUnmoved()
    {
        _unmoved.SetActive(true);
    }

    public void HideUnmoved()
    {
        _unmoved.SetActive(false);
    }
}