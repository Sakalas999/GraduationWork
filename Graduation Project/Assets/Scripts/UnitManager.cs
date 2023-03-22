using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;

    private List<ScriptableUnit> _units;

    public int HeroAmount;
    public int EnemyAmount;
    public int SelectedHeroIndex;
    public bool[] MovedHeroUnits;
    public bool[] MovedEnemyUnits;
    public BaseHero SelectedHero;
    public Tile[] HerosTile;
    public Tile[] EnemiesTile;
    public BaseEnemy[] Enemy;

    private int EnemyLeft;

    void Awake()
    {
        Instance = this;

        _units = Resources.LoadAll<ScriptableUnit>("Units").ToList();

        HerosTile = new Tile[HeroAmount];
        EnemiesTile = new Tile[EnemyAmount];
        MovedHeroUnits = new bool[HeroAmount];
        MovedEnemyUnits = new bool[EnemyAmount];
        Enemy = new BaseEnemy[EnemyAmount];

        EnemyLeft = EnemyAmount;

    }
    public void SpawnHeros()
    {
        for (int i = 0; i < HeroAmount; i++)
        {
            var randomPrefab = GetRandomUnit<BaseHero>(Faction.Hero);
            var spawnedHero = Instantiate(randomPrefab);
            var randomSpawnTile = GridManager.Instance.GetHeroSpawnTile();

            randomSpawnTile.SetUnit(spawnedHero);

            SetHerosTile(randomSpawnTile, i);

            UpdateHeroMovementAvailability(i, false);
        }

        GameManager.Instance.ChangeState(GameState.SpawnEnemies);
    }

    public void SpawnEnemies()
    {
        for (int i = 0; i < EnemyAmount; i++)
        {
            var randomPrefab = GetRandomUnit<BaseEnemy>(Faction.Enemy);
            var spawnedEnemy = Instantiate(randomPrefab);
            var randomSpawnTile = GridManager.Instance.GetEnemySpawnTile();

            randomSpawnTile.SetUnit(spawnedEnemy);

            SetEnemiesTile(randomSpawnTile, i);
            UpdateEnemyMovementAvailability(i, false);

            Enemy[i] = spawnedEnemy;
        }

        GameManager.Instance.ChangeState(GameState.HerosTurn);
    }

    private T GetRandomUnit<T>(Faction faction) where T : BaseUnit
    {
        return (T)_units.Where(u => u.Faction == faction).OrderBy(o => Random.value).First().UnitPrefab;
    }

    public void SetSelectedHero(BaseHero hero, Tile tile)
    {
        SelectedHero = hero;
        MenuManager.Instance.ShowSelectedHero(hero);

        if (tile != null)
        {
            for (int i = 0; i < HeroAmount; i++)
            {
                if (HerosTile[i] != null && tile.name == HerosTile[i].name)
                {
                    SelectedHeroIndex = i;
                }
            }
        }
    }

    public void SetHerosTile(Tile tile, int i)
    {
        HerosTile[i] = tile;

    }

    public void SetEnemiesTile(Tile tile, int i)
    {
        EnemiesTile[i] = tile;
    }

    public void UpdateEnemyUnitAmount(int amount)
    {
        EnemyLeft += amount;
    }

    public void EnemyMoves()
    {
        for (int i = 0; i < EnemyAmount; i++)
        {
            if (EnemiesTile[i] != null)
            {
                int closestIndex = 0;
                float[] distance = new float[HeroAmount];

            
                for (int j = 0; j < HeroAmount; j++)
                {
                    if (HerosTile[j] != null)
                    {
                        distance[j] = Vector2.Distance(HerosTile[j].transform.position, EnemiesTile[i].transform.position);

                        if (distance[j] < distance[closestIndex])
                        {
                            closestIndex = j;
                        }
                    }
                }


                var hero = (BaseHero)HerosTile[closestIndex].occupiedUnit;

                Vector2 heroPosition = new Vector2(HerosTile[closestIndex].transform.position.x, HerosTile[closestIndex].transform.position.y);
                Vector2 enemyPosition = new Vector2(EnemiesTile[i].transform.position.x, EnemiesTile[i].transform.position.y);

                if (Mathf.Abs(Vector2.Distance(heroPosition, enemyPosition)) == 1)
                {
                    hero.TakeDamage();
                    UpdateEnemyMovementAvailability(i, true);

                    int countMovedUnits = 0;
                    for (int j = 0; j < EnemyAmount; j++)
                    {
                        if (MovedEnemyUnits[j])
                        {
                            countMovedUnits++;
                        }
                    }

                    if (countMovedUnits == EnemyAmount)
                    {
                        GameManager.Instance.ChangeState(GameState.HerosTurn);
                        for (int j = 0; j < HeroAmount; j++)
                        {
                            UpdateHeroMovementAvailability(j, false);
                        }
                    }
                }

                var tile = GridManager.Instance.GetTileAtPosition(Enemy[i].Distance(HerosTile[closestIndex], EnemiesTile[i]));
                if (tile.occupiedUnit == null && tile !=null)
                {
                    tile.SetUnit(Enemy[i]);
                    EnemiesTile[i] = tile;
                    UpdateEnemyMovementAvailability(i, true);

                    int countMovedUnits = 0;
                    for (int j = 0; j < EnemyAmount; j++)
                    {
                        if (MovedEnemyUnits[j])
                        {
                            countMovedUnits++;
                        }
                    }

                    if (countMovedUnits == EnemyAmount)
                    {
                        GameManager.Instance.ChangeState(GameState.HerosTurn);
                        for (int j = 0; j < HeroAmount; j++)
                        {
                            UpdateHeroMovementAvailability(j, false);
                        }
                    }
                }
                else
                {
                    UpdateEnemyMovementAvailability(i, true);
                }

                if (hero.Health <= 0)
                {

                    Destroy(hero.gameObject);
                    HerosTile[closestIndex].SetUnit(Enemy[i]);
                    EnemiesTile[i] = HerosTile[closestIndex];
                    HerosTile[closestIndex] = null;
                    UpdateEnemyMovementAvailability(i, true);
                }

                int countHeros = 0;
                for (int j = 0; j < HeroAmount; j++)
                {
                    if (HerosTile[j] != null)
                    {
                        countHeros++;
                    }
                }

                if (countHeros == 0)
                {
                    GameManager.Instance.ChangeState(GameState.BattleLost);
                }
                else
                {
                    int countMovedUnits = 0;
                    for (int j = 0; j < EnemyAmount; j++)
                    {
                        if (MovedEnemyUnits[j])
                        {
                            countMovedUnits++;
                        }
                    }

                    if (countMovedUnits == EnemyLeft || countMovedUnits == countHeros)
                    {
                        GameManager.Instance.ChangeState(GameState.HerosTurn);
                        for (int j = 0; j < HeroAmount; j++)
                        {
                            UpdateHeroMovementAvailability(j, false);
                        }
                    }
                }
            }
        }
    }

    public void UpdateHeroMovementAvailability(int i, bool wasItMoved)
    {
        MovedHeroUnits[i] = wasItMoved;
    }

    public void UpdateEnemyMovementAvailability(int i, bool wasItMoved)
    {
        MovedEnemyUnits[i] = wasItMoved;
    }

    public void GetAvailableTiles(Tile tile, bool showTiles)
    {
        for (int i = 1; i < 3; i++)
        {
            for (int j = 1; j < 3; j++)
            {
                Tile _tileUp = GridManager.Instance.GetTileAtPosition(new Vector2(Mathf.RoundToInt(tile.transform.position.x), Mathf.RoundToInt(tile.transform.position.y + j)));
                if (_tileUp != null && showTiles)
                {
                    _tileUp.ShowAvailableTiles();
                }
                else
                {
                    if (_tileUp != null) _tileUp.DisablleAvailableTiles();
                }

                Tile _tileDown = GridManager.Instance.GetTileAtPosition(new Vector2(Mathf.RoundToInt(tile.transform.position.x), Mathf.RoundToInt(tile.transform.position.y - j)));
                if (_tileDown != null && showTiles)
                {
                    _tileDown.ShowAvailableTiles();
                }
                else
                {
                    if (_tileDown != null) _tileDown.DisablleAvailableTiles();
                }

                Tile _tileLeft = GridManager.Instance.GetTileAtPosition(new Vector2(Mathf.RoundToInt(tile.transform.position.x - i), Mathf.RoundToInt(tile.transform.position.y)));
                if (_tileLeft != null && showTiles)
                {
                    _tileLeft.ShowAvailableTiles();
                }
                else
                {
                    if (_tileLeft != null) _tileLeft.DisablleAvailableTiles();
                }

                Tile _tileRight = GridManager.Instance.GetTileAtPosition(new Vector2(Mathf.RoundToInt(tile.transform.position.x + i), Mathf.RoundToInt(tile.transform.position.y)));
                if (_tileRight != null && showTiles)
                {
                    _tileRight.ShowAvailableTiles();
                }
                else
                {
                    if (_tileRight != null) _tileRight.DisablleAvailableTiles();
                }
            }
        }

        Tile _tileDiagonallyUpR = GridManager.Instance.GetTileAtPosition(new Vector2(Mathf.RoundToInt(tile.transform.position.x + 1), Mathf.RoundToInt(tile.transform.position.y + 1)));
        if (_tileDiagonallyUpR != null && showTiles)
        {
            _tileDiagonallyUpR.ShowAvailableTiles();
        }
        else
        {
            if (_tileDiagonallyUpR != null) _tileDiagonallyUpR.DisablleAvailableTiles();
        }

        Tile _tileDiagonallyUpL = GridManager.Instance.GetTileAtPosition(new Vector2(Mathf.RoundToInt(tile.transform.position.x - 1), Mathf.RoundToInt(tile.transform.position.y + 1)));
        if (_tileDiagonallyUpL != null && showTiles)
        {
            _tileDiagonallyUpL.ShowAvailableTiles();
        }
        else
        {
            if (_tileDiagonallyUpL != null) _tileDiagonallyUpL.DisablleAvailableTiles();
        }

        Tile _tileDiagonallyDownR = GridManager.Instance.GetTileAtPosition(new Vector2(Mathf.RoundToInt(tile.transform.position.x + 1), Mathf.RoundToInt(tile.transform.position.y - 1)));
        if (_tileDiagonallyDownR != null && showTiles)
        {
            _tileDiagonallyDownR.ShowAvailableTiles();
        }
        else
        {
            if (_tileDiagonallyDownR != null) _tileDiagonallyDownR.DisablleAvailableTiles();
        }

        Tile _tileDiagonallyDownL = GridManager.Instance.GetTileAtPosition(new Vector2(Mathf.RoundToInt(tile.transform.position.x - 1), Mathf.RoundToInt(tile.transform.position.y - 1)));
        if (_tileDiagonallyDownL != null && showTiles)
        {
            _tileDiagonallyDownL.ShowAvailableTiles();
        }
        else
        {
            if (_tileDiagonallyDownL != null) _tileDiagonallyDownL.DisablleAvailableTiles();
        }
    }
}