using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : BaseUnit
{
    private int _type1 = 48;
    private int _type2 = 24;
    private int _type3 = 8;

    //Method to move enemy character in any direction depending on which will be closer to the closest hero unit
    public Tile Distance (Tile heroTile, Tile enemyTile, Type enemyType)
    {
        Tile[] availabelTiles;
        int n = 0;
        int closestIndex = 0;
        float distance;

        if (enemyType == Type.Enemy1)
        {
            availabelTiles = GetAvailableTiles(enemyTile, _type1, enemyType);
            n = _type1;
        }
        else if (enemyType == Type.Enemy2)
        {
            availabelTiles = GetAvailableTiles(enemyTile, _type2, enemyType);
            n = _type2;
        }
        else
        {
            availabelTiles = GetAvailableTiles(enemyTile, _type3, enemyType);
            n = _type3;
        }

        float closestDistance = Mathf.Abs(Vector2.Distance(heroTile.transform.position, enemyTile.transform.position));

        for (int i = 0; i < n; i++)
        {
            if (availabelTiles[i] != null)
            {
                distance = Mathf.Abs(Vector2.Distance(heroTile.transform.position, availabelTiles[i].transform.position));

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestIndex = i;
                }
            }
        }

        return availabelTiles[closestIndex];
    }

    //Method that takes all possible movement tiles of an enemy from it's current position and the array size depends on the enemy type
    public Tile[] GetAvailableTiles(Tile enemyPosition, int index, Type type)
    {
        Tile[] array = new Tile[index];

        int indexer = 0;

        if (type == Type.Enemy3)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int x = Mathf.RoundToInt(enemyPosition.transform.position.x + i);
                    int y = Mathf.RoundToInt(enemyPosition.transform.position.y + j);

                    Tile tile = GridManager.Instance.GetTileAtPosition(new Vector2(x, y));

                    if (tile != enemyPosition)
                    {
                        array[indexer] = tile;
                        indexer++;
                    }
                }
            }
        }
        else if (type == Type.Enemy2)
        {
            for (int i = -2; i <= 2; i++)
            {
                for (int j = -2; j <= 2; j++)
                {
                    int x = Mathf.RoundToInt(enemyPosition.transform.position.x + i);
                    int y = Mathf.RoundToInt(enemyPosition.transform.position.y + j);

                    Tile tile = GridManager.Instance.GetTileAtPosition(new Vector2(x, y));

                    if (tile != enemyPosition)
                    {
                        array[indexer] = tile;
                        indexer++;
                    }
                }
            }
        }
        else
        {
            for (int i = -3; i <= 3; i++)
            {
                for (int j = -3; j <= 3; j++)
                {
                    int x = Mathf.RoundToInt(enemyPosition.transform.position.x + i);
                    int y = Mathf.RoundToInt(enemyPosition.transform.position.y + j);

                    Tile tile = GridManager.Instance.GetTileAtPosition(new Vector2(x, y));

                    if (tile != enemyPosition)
                    {
                        array[indexer] = tile;
                        indexer++;
                    }
                }
            }
        }

        return array;

    }
}

