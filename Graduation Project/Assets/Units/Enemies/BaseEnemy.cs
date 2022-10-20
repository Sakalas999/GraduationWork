using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : BaseUnit
{
    public Vector2 Distance (Tile heroTile, Tile enemyTile)
    {
        float distanceX = enemyTile.transform.position.x - heroTile.transform.position.x;
        float distanceY = enemyTile.transform.position.y - heroTile.transform.position.y;

        if (distanceX < distanceY && enemyTile.transform.position.x > 1 && distanceX > 0 && distanceX != 0)
        {
            return new Vector2(Mathf.RoundToInt(enemyTile.transform.position.x - 2), Mathf.RoundToInt(enemyTile.transform.position.y));
        }
        if (distanceX < distanceY && enemyTile.transform.position.x < 15 && distanceX < 0 && distanceX != 0)
        {
            return new Vector2(Mathf.RoundToInt(enemyTile.transform.position.x + 2), Mathf.RoundToInt(enemyTile.transform.position.y));
        }
        if (distanceX > distanceY && enemyTile.transform.position.y > 1 && distanceY > 0 && distanceY != 0)
        {
            return new Vector2(Mathf.RoundToInt(enemyTile.transform.position.x), Mathf.RoundToInt(enemyTile.transform.position.y - 2));
        }
        if (distanceX > distanceY && enemyTile.transform.position.y < 8 && distanceY < 0 && distanceY != 0)
        {
            return new Vector2(Mathf.RoundToInt(enemyTile.transform.position.x), Mathf.RoundToInt(enemyTile.transform.position.y + 2));
        }

        if (distanceY == 0 && enemyTile.transform.position.x > 1 && distanceX > 0)
        {
            return new Vector2(Mathf.RoundToInt(enemyTile.transform.position.x - 2), Mathf.RoundToInt(enemyTile.transform.position.y));
        }
        if (distanceY == 0 && enemyTile.transform.position.x < 15 && distanceX < 0)
        {
            return new Vector2(Mathf.RoundToInt(enemyTile.transform.position.x + 2), Mathf.RoundToInt(enemyTile.transform.position.y));
        }
        if (distanceX == 0 && enemyTile.transform.position.y > 1 && distanceY > 0)
        {
            return new Vector2(Mathf.RoundToInt(enemyTile.transform.position.x), Mathf.RoundToInt(enemyTile.transform.position.y - 2));
        }
        if (distanceX == 0 && enemyTile.transform.position.y < 8 && distanceY < 0)
        {
            return new Vector2(Mathf.RoundToInt(enemyTile.transform.position.x), Mathf.RoundToInt(enemyTile.transform.position.y + 2));
        }

        else
            return new Vector2(Mathf.RoundToInt(enemyTile.transform.position.x), Mathf.RoundToInt(enemyTile.transform.position.y));
    }
}
