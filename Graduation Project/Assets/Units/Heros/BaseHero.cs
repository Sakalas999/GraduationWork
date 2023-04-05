using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHero : BaseUnit
{
    private int _type1 = 48;
    private int _type2 = 24;

    public bool CanItMove(Tile herpPosition, Tile selectedTile, Type heroType)
    {
        int n = 0;
        bool move = false;

        if (heroType == Type.Hero1)
        {
            n = _type1;

            Tile[] array = GetAvailableTiles(herpPosition, heroType);

            for (int i = 0; i < n; i++)
            {
                if (selectedTile == array[i])
                {
                    move = true;
                }
            }
        }
        else
        {
            n = _type2;

            Tile[] array = GetAvailableTiles(herpPosition, heroType);

            for (int i = 0; i < n; i++)
            {
                if (selectedTile == array[i])
                {
                    move = true;
                }
            }

        }

        return move;

    }

    public Tile[] GetAvailableTiles(Tile heroPosition, Type type)
    {
        int indexer = 0;

        if (type == Type.Hero2)
        {
            Tile[] array = new Tile[_type2];

            for (int i = -2; i <= 2; i++)
            {
                for (int j = -2; j <= 2; j++)
                {
                    int x = Mathf.RoundToInt(heroPosition.transform.position.x + i);
                    int y = Mathf.RoundToInt(heroPosition.transform.position.y + j);

                    Tile tile = GridManager.Instance.GetTileAtPosition(new Vector2(x, y));

                    if (tile != heroPosition)
                    {
                        array[indexer] = tile;
                        indexer++;
                    }
                }
            }
            return array;
        }
        else
        {
            Tile[] array = new Tile[_type1];

            for (int i = -3; i <= 3; i++)
            {
                for (int j = -3; j <= 3; j++)
                {
                    int x = Mathf.RoundToInt(heroPosition.transform.position.x + i);
                    int y = Mathf.RoundToInt(heroPosition.transform.position.y + j);

                    Tile tile = GridManager.Instance.GetTileAtPosition(new Vector2(x, y));

                    if (tile != heroPosition)
                    {
                        array[indexer] = tile;
                        indexer++;
                    }
                }
            }

            return array;
        }        

    }
}
