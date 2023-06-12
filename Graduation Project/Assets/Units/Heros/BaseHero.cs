using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHero : BaseUnit
{
    private int _type1 = 48;
    private int _type2 = 24;

    public bool isWounded = false;

    public void UpdateWounded(bool wounded, Type type)
    {
        if (wounded && !isWounded)
        {
            isWounded = wounded;

            if (type == Type.Hero1)
            {
                FindObjectOfType<Hero1>().UpdateIsWounded(isWounded);
            }
            else if (type == Type.Hero2)
            {
                FindObjectOfType<Hero2>().UpdateIsWounded(isWounded);
            }
            else if (type == Type.Hero3)
            {
                FindObjectOfType<Hero3>().UpdateIsWounded(isWounded);
            }
            else if (type == Type.Hero4)
            {
                FindObjectOfType<Hero4>().UpdateIsWounded(isWounded);
            }
            else
            {
                FindObjectOfType<Hero5>().UpdateIsWounded(isWounded);
            }
        } else if (wounded && isWounded)
        {
            if (type == Type.Hero1)
            {
                FindObjectOfType<Hero1>().Kill();
            }
            else if (type == Type.Hero2)
            {
                FindObjectOfType<Hero2>().Kill();
            }
            else if (type == Type.Hero3)
            {
                FindObjectOfType<Hero3>().Kill();
            }
            else if (type == Type.Hero4)
            {
                FindObjectOfType<Hero4>().Kill();
            }
            else
            {
                FindObjectOfType<Hero5>().Kill();
            }
        }
        else
        {
            isWounded = wounded;

            if (type == Type.Hero1)
            {
                FindObjectOfType<Hero1>().UpdateIsWounded(isWounded);
            }
            else if (type == Type.Hero2)
            {
                FindObjectOfType<Hero2>().UpdateIsWounded(isWounded);
            }
            else if (type == Type.Hero3)
            {
                FindObjectOfType<Hero3>().UpdateIsWounded(isWounded);
            }
            else if (type == Type.Hero4)
            {
                FindObjectOfType<Hero4>().UpdateIsWounded(isWounded);
            }
            else
            {
                FindObjectOfType<Hero5>().UpdateIsWounded(isWounded);
            }
        }
    }

    public bool CanItMove(Tile herpPosition, Tile selectedTile, Type heroType)
    {
        int n = 0;
        bool move = false;

        if (heroType == Type.Hero1 || heroType == Type.Hero3 || heroType == Type.Hero5)
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
        float debuff;

        if (isWounded)
        {
            debuff = 0.5f;
        }
        else
        {
            debuff = 1;
        }

        if (type == Type.Hero2 || type == Type.Hero4)
        {     
            Tile[] array = new Tile[_type2];

            for (int i = Mathf.RoundToInt (- 2 * debuff) ; i <= Mathf.RoundToInt(2 * debuff); i++)
            {
                for (int j = Mathf.RoundToInt(-2 * debuff); j <= Mathf.RoundToInt(2 * debuff); j++)
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

            for (int i = Mathf.RoundToInt(-3 * debuff); i <= Mathf.RoundToInt(3 * debuff); i++)
            {
                for (int j = Mathf.RoundToInt(-3 * debuff); j <= Mathf.RoundToInt(3 * debuff); j++)
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
