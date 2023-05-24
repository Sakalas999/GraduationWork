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
    public int[] HeroTypes = new int[2];
    public int[] EnemyTypes = new int[3];
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

        HeroAmount = PlayerPrefs.GetInt("amountOfUnits");
        EnemyAmount = PlayerPrefs.GetInt("enemyAmount");
        
        if (PlayerPrefs.GetInt("ratHero") != 0)
        {
            HeroTypes[0] = 1;
        }
        if (PlayerPrefs.GetInt("dogHero") != 0)
        {
            HeroTypes[1] = 1;
        }
        if (PlayerPrefs.GetInt("ratHero") == 0)
        {
            HeroTypes[0] = 0;
        }
        if (PlayerPrefs.GetInt("dogHero") == 0)
        {
            HeroTypes[1] = 0;
        }

        if (PlayerPrefs.GetInt("firstTypeEnemies") != 0)
        {
            EnemyTypes[0] = PlayerPrefs.GetInt("firstTypeEnemies");
        }
        if (PlayerPrefs.GetInt("secondTypeEnemies") != 0)
        {
            EnemyTypes[1] = PlayerPrefs.GetInt("secondTypeEnemies");
        }
        if (PlayerPrefs.GetInt("thirdTypeEnemies") != 0)
        {
            EnemyTypes[2] = PlayerPrefs.GetInt("ThirdTypeEnemies");
        }
        if (PlayerPrefs.GetInt("firstTypeEnemies") == 0)
        {
            EnemyTypes[0] = 0;
        }
        if (PlayerPrefs.GetInt("secondTypeEnemies") == 0)
        {
            EnemyTypes[1] = 0;
        }
        if (PlayerPrefs.GetInt("thirdTypeEnemies") == 0)
        {
            EnemyTypes[2] = 0;
        }

        HerosTile = new Tile[HeroAmount];
        EnemiesTile = new Tile[EnemyAmount];
        MovedHeroUnits = new bool[HeroAmount];
        MovedEnemyUnits = new bool[EnemyAmount];
        Enemy = new BaseEnemy[EnemyAmount];

        EnemyLeft = EnemyAmount;

    }

    //Spawns hero units on the grid
    public void SpawnHeros()
    {
        int counter = 0;
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < HeroTypes[i]; j++)
            {
                if (i == 0)
                {
                    var randomPrefab = GetRandomUnit<BaseHero>(Faction.Hero);
                    do
                    {
                        randomPrefab = GetRandomUnit<BaseHero>(Faction.Hero);
                    } while (randomPrefab.Type != Type.Hero1);
                    var spawnedHero = Instantiate(randomPrefab);

                    var randomSpawnTile = GridManager.Instance.GetHeroSpawnTile();

                    randomSpawnTile.SetUnit(spawnedHero);

                    SetHerosTile(randomSpawnTile, counter);

                    UpdateHeroMovementAvailability(counter, false);
                    counter++;
                }
                else
                {
                    var randomPrefab = GetRandomUnit<BaseHero>(Faction.Hero);
                    do
                    {
                        randomPrefab = GetRandomUnit<BaseHero>(Faction.Hero);
                    } while (randomPrefab.Type != Type.Hero2);

                    var spawnedHero = Instantiate(randomPrefab);
                    var randomSpawnTile = GridManager.Instance.GetHeroSpawnTile();

                    randomSpawnTile.SetUnit(spawnedHero);

                    SetHerosTile(randomSpawnTile, counter);

                    UpdateHeroMovementAvailability(counter, false);
                    counter++;
                }
            }
        }

        GameManager.Instance.ChangeState(GameState.SpawnEnemies);
    }

    public void SpawnEnemies()
    {
        int counter = 0;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < EnemyTypes[i]; j++)
            {
                if (i == 0)
                {
                    var randomPrefab = GetRandomUnit<BaseEnemy>(Faction.Enemy);
                    do
                    {
                        randomPrefab = GetRandomUnit<BaseEnemy>(Faction.Enemy);
                    } while (randomPrefab.Type != Type.Enemy1);

                    var spawnedEnemy = Instantiate(randomPrefab);
                    var randomSpawnTile = GridManager.Instance.GetEnemySpawnTile();

                    randomSpawnTile.SetUnit(spawnedEnemy);

                    SetEnemiesTile(randomSpawnTile, counter);
                    UpdateEnemyMovementAvailability(counter, false);

                    Enemy[counter] = spawnedEnemy;
                    counter++;
                }
                else if (i == 1)
                {
                    var randomPrefab = GetRandomUnit<BaseEnemy>(Faction.Enemy);
                    do
                    {
                        randomPrefab = GetRandomUnit<BaseEnemy>(Faction.Enemy);
                    } while (randomPrefab.Type != Type.Enemy2);

                    var spawnedEnemy = Instantiate(randomPrefab);
                    var randomSpawnTile = GridManager.Instance.GetEnemySpawnTile();

                    randomSpawnTile.SetUnit(spawnedEnemy);

                    SetEnemiesTile(randomSpawnTile, counter);
                    UpdateEnemyMovementAvailability(counter, false);

                    Enemy[counter] = spawnedEnemy;
                    counter++;
                }
                else
                {
                    var randomPrefab = GetRandomUnit<BaseEnemy>(Faction.Enemy);
                    do
                    {
                        randomPrefab = GetRandomUnit<BaseEnemy>(Faction.Enemy);
                    } while (randomPrefab.Type != Type.Enemy3);

                    var spawnedEnemy = Instantiate(randomPrefab);
                    var randomSpawnTile = GridManager.Instance.GetEnemySpawnTile();

                    randomSpawnTile.SetUnit(spawnedEnemy);

                    SetEnemiesTile(randomSpawnTile, counter);
                    UpdateEnemyMovementAvailability(counter, false);

                    Enemy[counter] = spawnedEnemy;
                    counter++;
                }
            }
        }

        GameManager.Instance.ChangeState(GameState.HerosTurn);
    }

    //Get's a random unit of a specific faction (currently there's one option for either hero or enemy faction)
    private T GetRandomUnit<T>(Faction faction) where T : BaseUnit
    {
        return (T)_units.Where(u => u.Faction == faction).OrderBy(o => Random.value).First().UnitPrefab;
    }

    //Method that sets the selected hero unit
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

    //We set a tile that is occupied by a specific hero unit
    public void SetHerosTile(Tile tile, int i)
    {
        HerosTile[i] = tile;

    }

    //We set a tile that is occupied by a specific enemy unit 
    public void SetEnemiesTile(Tile tile, int i)
    {
        EnemiesTile[i] = tile;
    }

    //Updates the enemies left on the grid
    public void UpdateEnemyUnitAmount(int amount)
    {
        EnemyLeft += amount;
    }

    //Method for enemy unit movement
    public void EnemyMoves()
    {
        for (int i = 0; i < EnemyAmount; i++)
        {
            Debug.Log(i + " moved");
            if (EnemiesTile[i] != null)
            {
                int closestIndex = 0;
                float[] distance = new float[HeroAmount];

            
                //Finds the closest hero unit to the specific enemy unit
                for (int j = 0; j < HeroAmount; j++)
                {
                    if (HerosTile[j] != null)
                    {
                        distance[j] = Mathf.Abs(Vector2.Distance(HerosTile[j].transform.position, EnemiesTile[i].transform.position));

                        if (distance[j] < distance[closestIndex] && HerosTile[closestIndex] != null)
                        {
                            closestIndex = j;
                        }
                        else
                        {
                            closestIndex = j;
                        }
                    }
                }


                var hero = (BaseHero)HerosTile[closestIndex].occupiedUnit;

                Vector2 heroPosition = new Vector2(HerosTile[closestIndex].transform.position.x, HerosTile[closestIndex].transform.position.y);
                Vector2 enemyPosition = new Vector2(EnemiesTile[i].transform.position.x, EnemiesTile[i].transform.position.y);

                //If a hero character is close to the enemy then it attacks
                if (Mathf.Abs(Vector2.Distance(heroPosition, enemyPosition)) <= 1 && !MovedEnemyUnits[i])
                {
                    if (Enemy[i].Type == Type.Enemy1)
                    {
                        hero.TakeDamage(1);
                    }

                    if (Enemy[i].Type == Type.Enemy2)
                    {
                        hero.TakeDamage(2);
                    }

                    if (Enemy[i].Type == Type.Enemy3)
                    {
                        hero.TakeDamage(3);
                    }
                    UpdateEnemyMovementAvailability(i, true);
                }

                var tile = Enemy[i].Distance(HerosTile[closestIndex], EnemiesTile[i], Enemy[i].Type);

                //Moves an enemy unit to another tile
                if (tile.occupiedUnit == null && tile !=null) 
                {
                    tile.SetUnit(Enemy[i]);
                    EnemiesTile[i] = tile;
                    UpdateEnemyMovementAvailability(i, true);
                }
                else
                {

                    UpdateEnemyMovementAvailability(i, true);
                }

                //If a hero unit has 0 or less health then the hero unit is destroyed and the enemy character moves to it's tile
                if (hero.Health <= 0)
                {
                    hero.UpdateWounded(true, hero.Type); 
                    Destroy(hero.gameObject);
                    HerosTile[closestIndex].SetUnit(Enemy[i]);
                    EnemiesTile[i] = HerosTile[closestIndex];
                    HerosTile[closestIndex] = null;
                    UpdateEnemyMovementAvailability(i, true);
                }

                //Counts how many heros are on the grid
                int countHeros = 0;
                for (int j = 0; j < HeroAmount; j++)
                {
                    if (HerosTile[j] != null)
                    {
                        countHeros++;
                    }
                }

                //When there's no hero characters left the battle ends
                if (countHeros == 0)
                {
                    GameManager.Instance.ChangeState(GameState.BattleLost);
                }
                else
                {
                    //Counts how many enemy untis moved
                    int countMovedUnits = 0;
                    for (int j = 0; j < EnemyAmount; j++)
                    {
                        if (MovedEnemyUnits[j])
                        {
                            countMovedUnits++;
                        }
                    }

                    //When all enemy characters have moved change game state to heros turn
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

    //Updates whether or not the specific hero unit has been moved
    public void UpdateHeroMovementAvailability(int i, bool wasItMoved)
    {
        MovedHeroUnits[i] = wasItMoved;
    }

    //Updates whether or not the specific enemy unit has been moved
    public void UpdateEnemyMovementAvailability(int i, bool wasItMoved)
    {
        MovedEnemyUnits[i] = wasItMoved;
    }

    //Displays available tiles around the enemy unit
    public void GetAvailableTiles(BaseUnit occupiedUnit, Tile tile, bool showTiles)
    {
        int n = 0;

        if (showTiles)
        {
            if (occupiedUnit.Faction == Faction.Hero)
            {
                if (occupiedUnit.Type == Type.Hero1)
                {
                    n = 48;
                    BaseHero hero = (BaseHero)occupiedUnit;
                    Tile[] array = hero.GetAvailableTiles(tile, Type.Hero1);

                    for (int i = 0; i < n; i++)
                    {
                        if (array[i] != null)
                        array[i].ShowAvailableTiles();
                    }
                }
                else
                {
                    n = 24;
                    BaseHero hero = (BaseHero)occupiedUnit;
                    Tile[] array = hero.GetAvailableTiles(tile, Type.Hero2);

                    for (int i = 0; i < n; i++)
                    {
                        if (array[i] != null)
                        array[i].ShowAvailableTiles();
                    }
                }
            }
            else
            {
                if (occupiedUnit.Type == Type.Enemy1)
                {
                    n = 48;
                    BaseEnemy enemy = (BaseEnemy)occupiedUnit;
                    Tile[] array = enemy.GetAvailableTiles(tile, n, Type.Enemy1);

                    for (int i = 0; i < n; i++)
                    {
                        if (array[i] != null)
                            array[i].ShowAvailableTiles();
                    }
                }
                else if (occupiedUnit.Type == Type.Enemy2)
                {
                    n = 24;
                    BaseEnemy enemy = (BaseEnemy)occupiedUnit;
                    Tile[] array = enemy.GetAvailableTiles(tile, n, Type.Enemy2);

                    for (int i = 0; i < n; i++)
                    {
                        if (array[i] != null)
                            array[i].ShowAvailableTiles();
                    }
                }
                else
                {
                    n = 8;
                    BaseEnemy enemy = (BaseEnemy)occupiedUnit;
                    Tile[] array = enemy.GetAvailableTiles(tile, n, Type.Enemy3);

                    for (int i = 0; i < n; i++)
                    {
                        if (array[i] != null)
                            array[i].ShowAvailableTiles();
                    }
                }
            }
        }
        else
        {
            if (occupiedUnit.Faction == Faction.Hero)
            {
                if (occupiedUnit.Type == Type.Hero1)
                {
                    n = 48;
                    BaseHero hero = (BaseHero)occupiedUnit;
                    Tile[] array = hero.GetAvailableTiles(tile, Type.Hero1);

                    for (int i = 0; i < n; i++)
                    {
                        if (array[i] != null)
                            array[i].DisablleAvailableTiles();
                    }
                }
                else
                {
                    n = 24;
                    BaseHero hero = (BaseHero)occupiedUnit;
                    Tile[] array = hero.GetAvailableTiles(tile, Type.Hero2);

                    for (int i = 0; i < n; i++)
                    {
                        if (array[i] != null)
                            array[i].DisablleAvailableTiles();
                    }
                }
            }
            else
            {
                if (occupiedUnit.Type == Type.Enemy1)
                {
                    n = 48;
                    BaseEnemy enemy = (BaseEnemy)occupiedUnit;
                    Tile[] array = enemy.GetAvailableTiles(tile, n, Type.Enemy1);

                    for (int i = 0; i < n; i++)
                    {
                        if (array[i] != null)
                            array[i].DisablleAvailableTiles();
                    }
                }
                else if (occupiedUnit.Type == Type.Enemy2)
                {
                    n = 24;
                    BaseEnemy enemy = (BaseEnemy)occupiedUnit;
                    Tile[] array = enemy.GetAvailableTiles(tile, n, Type.Enemy2);

                    for (int i = 0; i < n; i++)
                    {
                        if (array[i] != null)
                            array[i].DisablleAvailableTiles();
                    }
                }
                else
                {
                    n = 8;
                    BaseEnemy enemy = (BaseEnemy)occupiedUnit;
                    Tile[] array = enemy.GetAvailableTiles(tile, n, Type.Enemy3);

                    for (int i = 0; i < n; i++)
                    {
                        if (array[i] != null)
                            array[i].DisablleAvailableTiles();
                    }
                }
            }
        }
    }
}