using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;

    private List<ScriptableUnit> _units;

    public BaseHero SelectedHero;
    public Tile HerosTile;
    public Tile EnemiesTile;
    public BaseEnemy Enemy;

    void Awake()
    {
        Instance = this;

        _units = Resources.LoadAll<ScriptableUnit>("Units").ToList();

    }
    public void SpawnHeros()
    {
        var randomPrefab = GetRandomUnit<BaseHero>(Faction.Hero);
        var spawnedHero = Instantiate(randomPrefab);
        var randomSpawnTile = GridManager.Instance.GetHeroSpawnTile();

        randomSpawnTile.SetUnit(spawnedHero);

        SetHerosTile(randomSpawnTile);

        GameManager.Instance.ChangeState(GameState.SpawnEnemies);
    }

    public void SpawnEnemies()
    {
        var randomPrefab = GetRandomUnit<BaseEnemy>(Faction.Enemy);
        var spawnedEnemy = Instantiate(randomPrefab);
        var randomSpawnTile = GridManager.Instance.GetEnemySpawnTile();

        randomSpawnTile.SetUnit(spawnedEnemy);

        SetEnemiesTile(randomSpawnTile);

        Enemy = spawnedEnemy;

        GameManager.Instance.ChangeState(GameState.HerosTurn);
    }

    private T GetRandomUnit<T>(Faction faction) where T : BaseUnit
    {
        return (T)_units.Where(u => u.Faction == faction).OrderBy(o => Random.value).First().UnitPrefab;
    }

    public void SetSelectedHero(BaseHero hero)
    {
        SelectedHero = hero;
        MenuManager.Instance.ShowSelectedHero(hero);
    }

    public void SetHerosTile(Tile tile)
    {
        HerosTile = tile;

    }

    public void SetEnemiesTile(Tile tile)
    {
        EnemiesTile = tile;
    }

    public void EnemyMoves()
    {
        var hero = (BaseHero)HerosTile.occupiedUnit;
        bool isClose = false;

        Vector2 heroPosition = new Vector2(HerosTile.transform.position.x, HerosTile.transform.position.y);
        Vector2 enemyPosition = new Vector2(EnemiesTile.transform.position.x, EnemiesTile.transform.position.y);

        if (Mathf.Abs(Vector2.Distance(heroPosition, enemyPosition)) == 1)
        {
            hero.TakeDamage();
            isClose = true;
            GameManager.Instance.ChangeState(GameState.HerosTurn);
        }
        else
        {
            isClose = false;
        }

        var tile = GridManager.Instance.GetTileAtPosition(Enemy.Distance(HerosTile, EnemiesTile));
        if (tile.name != HerosTile.name && !isClose)
        {
            tile.SetUnit(Enemy);
            EnemiesTile = tile;
            GameManager.Instance.ChangeState(GameState.HerosTurn);
        }
        
        if(hero.Health <= 0)
        {

            Destroy(hero.gameObject);
            HerosTile.SetUnit(Enemy);
            EnemiesTile = HerosTile;
            HerosTile = null;     
        }

        if (HerosTile == null)
        {
            GameManager.Instance.ChangeState(GameState.BattleLost);
        }
        else
        {
            GameManager.Instance.ChangeState(GameState.HerosTurn);
        }
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