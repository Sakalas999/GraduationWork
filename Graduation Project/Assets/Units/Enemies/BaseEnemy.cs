using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : BaseUnit
{
    public Vector2 Distance (Tile heroTile, Tile enemyTile)
    {
        int distanceX = Mathf.RoundToInt(enemyTile.transform.position.x - heroTile.transform.position.x);
        int distanceY = Mathf.RoundToInt(enemyTile.transform.position.y - heroTile.transform.position.y);

        if (distanceX < distanceY && distanceX > 1)
        {
            return new Vector2(Mathf.RoundToInt(enemyTile.transform.position.x - 2), Mathf.RoundToInt(enemyTile.transform.position.y));
        }
        if (distanceX < distanceY && distanceX < 1)
        {
            return new Vector2(Mathf.RoundToInt(enemyTile.transform.position.x + 2), Mathf.RoundToInt(enemyTile.transform.position.y));
        }
        if (distanceX > distanceY && distanceY > 1)
        {
            return new Vector2(Mathf.RoundToInt(enemyTile.transform.position.x), Mathf.RoundToInt(enemyTile.transform.position.y - 2));
        }
        if (distanceX > distanceY && distanceY < 1)
        {
            return new Vector2(Mathf.RoundToInt(enemyTile.transform.position.x), Mathf.RoundToInt(enemyTile.transform.position.y + 2));
        }

        else
            return new Vector2(Mathf.RoundToInt(enemyTile.transform.position.x), Mathf.RoundToInt(enemyTile.transform.position.y));
    }
}
