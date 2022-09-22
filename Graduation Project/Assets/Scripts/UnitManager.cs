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

        GameManager.Instance.ChangeState(GameState.SpawnEnemies);
    }

    public void SpawnEnemies()
    {
        var randomPrefab = GetRandomUnit<BaseEnemy>(Faction.Enemy);
        var spawnedEnemy = Instantiate(randomPrefab);
        var randomSpawnTile = GridManager.Instance.GetEnemySpawnTile();

        randomSpawnTile.SetUnit(spawnedEnemy);

        GameManager.Instance.ChangeState(GameState.HerosTurn);
    }

    private T GetRandomUnit<T>(Faction faction) where T : BaseUnit
    {
        return (T)_units.Where(u => u.Faction == faction).OrderBy(o => Random.value).First().UnitPrefab;
    }
}