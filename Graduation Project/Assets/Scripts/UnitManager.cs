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

    public void EnemyMoves()
    {
        var hero = (BaseHero)HerosTile.occupiedUnit;
        Destroy(hero.gameObject);
        HerosTile.SetUnit(Enemy);
    }
}