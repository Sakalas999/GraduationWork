using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoOnOwnedCharacters : MonoBehaviour
{
    public static InfoOnOwnedCharacters Instance;

    public bool isOwnedH1;
    public bool isOwnedH2;
    public bool isOwnedH3;
    public bool isOwnedH4;
    public bool isOwnedH5;

    public bool isWoundedH1;
    public bool isWoundedH2;

    public bool isDeadH1;
    public bool isDeadH2;

    public int amountOfUnits = 0;

    private void Awake()
    {
        Instance = this;
        PlayerPrefs.SetInt("isOwnedH1", 1);
        PlayerPrefs.SetInt("isOwnedH2", 0);

        PlayerPrefs.SetInt("isWoundedH1", 0);
        PlayerPrefs.SetInt("isWoundedH2", 0);

        PlayerPrefs.SetInt("isDeadH1", 0);
        PlayerPrefs.SetInt("isDeadH2", 0);

        isOwnedH1 = intToBool(PlayerPrefs.GetInt("isOwnedH1"));
        if (isOwnedH1) amountOfUnits++;
        isOwnedH2 = intToBool(PlayerPrefs.GetInt("isOwnedH2"));
        if (isOwnedH2) amountOfUnits++;

        isWoundedH1 = intToBool(PlayerPrefs.GetInt("isWoundedH1"));
        isWoundedH2 = intToBool(PlayerPrefs.GetInt("isWoundedH2"));

        isDeadH1 = intToBool(PlayerPrefs.GetInt("isDeadH1"));
        isDeadH2 = intToBool(PlayerPrefs.GetInt("isDeadH2"));

        PlayerPrefs.SetInt("amountOfUnits", amountOfUnits);
        PlayerPrefs.SetInt("ratHero", 0);
        PlayerPrefs.SetInt("dogHero", 0);
        RemoveEnemy();
    }

    public void UpdateWounded(int which, bool wounded)
    {
        switch (which)
        {
            case 1:
                if (wounded)
                {
                    if (!isWoundedH1)
                    {
                        PlayerPrefs.SetInt("isWoundedH1", 1);
                        isWoundedH1 = true;
                    }
                    else
                    {
                        UpdateDead(1, true);
                        PlayerPrefs.SetInt("isWoundedH1", 0);
                        isWoundedH1 = false;
                    }
                }
                else
                {
                    PlayerPrefs.SetInt("isWoundedH1", 0);
                    isWoundedH1 = false;
                }
                PlayerPrefs.Save();
                break;
            case 2:
                if (wounded)
                {
                    if (!isWoundedH2)
                    {
                        PlayerPrefs.SetInt("isWoundedH2", 1);
                        isWoundedH2 = true;
                    }
                    else
                    {
                        UpdateDead(2, true);
                        PlayerPrefs.SetInt("isWoundedH2", 0);
                        isWoundedH2 = false;
                    }
                }
                else
                {
                    PlayerPrefs.SetInt("isWoundedH2", 0);
                    isWoundedH2 = false;
                }
                PlayerPrefs.Save();
                break;
        }

    }

    public void UpdateDead(int which, bool dead)
    {
        switch (which)
        {
            case 1:
                if (dead)
                {
                    PlayerPrefs.SetInt("isDeadH1", 1);
                    isDeadH1 = true;
                    UpdateOwned(1, false);
                }
                else
                {
                    PlayerPrefs.SetInt("isDeadH1", 0);
                    isDeadH1 = false;
                }
                PlayerPrefs.Save();
                break;
            case 2:
                if (dead)
                {
                    PlayerPrefs.SetInt("isDeadH2", 1);
                    isDeadH2 = true;
                    UpdateOwned(2, false);
                }
                else
                {
                    PlayerPrefs.SetInt("isDeadH2", 0);
                    isDeadH2 = false;
                }
                PlayerPrefs.Save();
                break;
        }
    }

    public void UpdateOwned(int which, bool owned)
    {
        switch (which)
        {
            case 1:
                if (owned)
                {
                    PlayerPrefs.SetInt("isOwnedH1", 1);
                    amountOfUnits++;
                    PlayerPrefs.SetInt("amountOfUnits", amountOfUnits);
                    isOwnedH1 = true;
                }
                else
                {
                    PlayerPrefs.SetInt("isOwnedH1", 0);
                    amountOfUnits--;
                    PlayerPrefs.SetInt("amountOfUnits", amountOfUnits);
                    isOwnedH1 = false;
                }
                PlayerPrefs.Save();
                break;
            case 2:
                if (owned)
                {
                    PlayerPrefs.SetInt("isOwnedH2", 1);
                    amountOfUnits++;
                    PlayerPrefs.SetInt("amountOfUnits", amountOfUnits);
                    isOwnedH2 = true;
                }
                else
                {
                    PlayerPrefs.SetInt("isOwnedH2", 0);
                    amountOfUnits--;
                    PlayerPrefs.SetInt("amountOfUnits", amountOfUnits);
                    isOwnedH2 = false;
                }
                PlayerPrefs.Save();
                break;
        }
    }

    public void AddEnemy(int amount, int firstTypeAmount, int secondTypeAmount, int thirdTypeAmount)
    {
        PlayerPrefs.SetInt("enemyAmount", amount);
        PlayerPrefs.SetInt("firstTypeEnemies", firstTypeAmount);
        PlayerPrefs.SetInt("secondTypeEnemies", secondTypeAmount);
        PlayerPrefs.SetInt("thirdTypeEnemies", thirdTypeAmount);
    }

    public void RemoveEnemy()
    {
        PlayerPrefs.SetInt("enemyAmount", 0);
        PlayerPrefs.SetInt("firstTypeEnemies", 0);
        PlayerPrefs.SetInt("secondTypeEnemies", 0);
        PlayerPrefs.SetInt("thirdTypeEnemies", 0);
    }

    public void SelectedHeros(int index)
    {
        if (index == 1)
        {
            PlayerPrefs.SetInt("ratHero", 1);
        }
        if (index == 2)
        {
            PlayerPrefs.SetInt("dogHero", 1);
        }
    }

    public void DeselectHero(int index)
    {
        if (index == 1)
        {
            PlayerPrefs.SetInt("ratHero", 0);
        }
        if (index == 2)
        {
            PlayerPrefs.SetInt("dogHero", 0);
        }
    }

    private bool intToBool(int val)
    {
        if (val != 0)
            return true;
        else
            return false;
    }
}
