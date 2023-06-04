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
    public bool isWoundedH3;
    public bool isWoundedH4;
    public bool isWoundedH5;

    public bool isDeadH1;
    public bool isDeadH2;
    public bool isDeadH3;
    public bool isDeadH4;
    public bool isDeadH5;

    public int healthEffects1;
    public int healthEffects2;
    public int healthEffects3;
    public int healthEffects4;
    public int healthEffects5;

    public int amountOfUnits = 0;

    private void Awake()
    {
        Instance = this;
        PlayerPrefs.SetInt("isOwnedH1", 1);
        PlayerPrefs.SetInt("isOwnedH2", 0);
        PlayerPrefs.SetInt("isOwnedH3", 0);
        PlayerPrefs.SetInt("isOwnedH4", 0);
        PlayerPrefs.SetInt("isOwnedH5", 0);

        PlayerPrefs.SetInt("isWoundedH1", 0);
        PlayerPrefs.SetInt("isWoundedH2", 0);
        PlayerPrefs.SetInt("isWoundedH3", 0);
        PlayerPrefs.SetInt("isWoundedH4", 0);
        PlayerPrefs.SetInt("isWoundedH5", 0);

        PlayerPrefs.SetInt("isDeadH1", 0);
        PlayerPrefs.SetInt("isDeadH2", 0);
        PlayerPrefs.SetInt("isDeadH3", 0);
        PlayerPrefs.SetInt("isDeadH4", 0);
        PlayerPrefs.SetInt("isDeadH5", 0);

        PlayerPrefs.SetInt("HealthEffectsH1", 0);
        PlayerPrefs.SetInt("HealthEffectsH2", 0);
        PlayerPrefs.SetInt("HealthEffectsH3", 0);
        PlayerPrefs.SetInt("HealthEffectsH4", 0);
        PlayerPrefs.SetInt("HealthEffectsH5", 0);


        isOwnedH1 = intToBool(PlayerPrefs.GetInt("isOwnedH1"));
        if (isOwnedH1) amountOfUnits++;
        isOwnedH2 = intToBool(PlayerPrefs.GetInt("isOwnedH2"));
        if (isOwnedH2) amountOfUnits++;
        isOwnedH3 = intToBool(PlayerPrefs.GetInt("isOwnedH3"));
        if (isOwnedH3) amountOfUnits++;
        isOwnedH4 = intToBool(PlayerPrefs.GetInt("isOwnedH4"));
        if (isOwnedH4) amountOfUnits++;
        isOwnedH5 = intToBool(PlayerPrefs.GetInt("isOwnedH5"));
        if (isOwnedH5) amountOfUnits++;

        isWoundedH1 = intToBool(PlayerPrefs.GetInt("isWoundedH1"));
        isWoundedH2 = intToBool(PlayerPrefs.GetInt("isWoundedH2"));
        isWoundedH3 = intToBool(PlayerPrefs.GetInt("isWoundedH3"));
        isWoundedH4 = intToBool(PlayerPrefs.GetInt("isWoundedH4"));
        isWoundedH5 = intToBool(PlayerPrefs.GetInt("isWoundedH5"));

        isDeadH1 = intToBool(PlayerPrefs.GetInt("isDeadH1"));
        isDeadH2 = intToBool(PlayerPrefs.GetInt("isDeadH2"));
        isDeadH3 = intToBool(PlayerPrefs.GetInt("isDeadH3"));
        isDeadH4 = intToBool(PlayerPrefs.GetInt("isDeadH4"));
        isDeadH5 = intToBool(PlayerPrefs.GetInt("isDeadH5"));

        healthEffects1 = PlayerPrefs.GetInt("HealthEffectsH1");
        healthEffects2 = PlayerPrefs.GetInt("HealthEffectsH2");
        healthEffects3 = PlayerPrefs.GetInt("HealthEffectsH3");
        healthEffects4 = PlayerPrefs.GetInt("HealthEffectsH4");
        healthEffects5 = PlayerPrefs.GetInt("HealthEffectsH5");

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
            case 3:
                if (wounded)
                {
                    if (!isWoundedH3)
                    {
                        PlayerPrefs.SetInt("isWoundedH3", 1);
                        isWoundedH3 = true;
                    }
                    else
                    {
                        UpdateDead(3, true);
                        PlayerPrefs.SetInt("isWoundedH3", 0);
                        isWoundedH3 = false;
                    }
                }
                else
                {
                    PlayerPrefs.SetInt("isWoundedH3", 0);
                    isWoundedH3 = false;
                }
                PlayerPrefs.Save();
                break;
            case 4:
                if (wounded)
                {
                    if (!isWoundedH4)
                    {
                        PlayerPrefs.SetInt("isWoundedH4", 1);
                        isWoundedH4 = true;
                    }
                    else
                    {
                        UpdateDead(4, true);
                        PlayerPrefs.SetInt("isWoundedH4", 0);
                        isWoundedH4 = false;
                    }
                }
                else
                {
                    PlayerPrefs.SetInt("isWoundedH4", 0);
                    isWoundedH4 = false;
                }
                PlayerPrefs.Save();
                break;
            case 5:
                if (wounded)
                {
                    if (!isWoundedH5)
                    {
                        PlayerPrefs.SetInt("isWoundedH5", 1);
                        isWoundedH5 = true;
                    }
                    else
                    {
                        UpdateDead(5, true);
                        PlayerPrefs.SetInt("isWoundedH5", 0);
                        isWoundedH5 = false;
                    }
                }
                else
                {
                    PlayerPrefs.SetInt("isWoundedH5", 0);
                    isWoundedH5 = false;
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
            case 3:
                if (dead)
                {
                    PlayerPrefs.SetInt("isDeadH3", 1);
                    isDeadH3 = true;
                    UpdateOwned(3, false);
                }
                else
                {
                    PlayerPrefs.SetInt("isDeadH3", 0);
                    isDeadH3 = false;
                }
                PlayerPrefs.Save();
                break;
            case 4:
                if (dead)
                {
                    PlayerPrefs.SetInt("isDeadH4", 1);
                    isDeadH4 = true;
                    UpdateOwned(4, false);
                }
                else
                {
                    PlayerPrefs.SetInt("isDeadH4", 0);
                    isDeadH4 = false;
                }
                PlayerPrefs.Save();
                break;
            case 5:
                if (dead)
                {
                    PlayerPrefs.SetInt("isDeadH5", 1);
                    isDeadH5 = true;
                    UpdateOwned(5, false);
                }
                else
                {
                    PlayerPrefs.SetInt("isDeadH5", 0);
                    isDeadH5 = false;
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
            case 3:
                if (owned)
                {
                    PlayerPrefs.SetInt("isOwnedH3", 1);
                    amountOfUnits++;
                    PlayerPrefs.SetInt("amountOfUnits", amountOfUnits);
                    isOwnedH3 = true;
                }
                else
                {
                    PlayerPrefs.SetInt("isOwnedH3", 0);
                    amountOfUnits--;
                    PlayerPrefs.SetInt("amountOfUnits", amountOfUnits);
                    isOwnedH3 = false;
                }
                PlayerPrefs.Save();
                break;
            case 4:
                if (owned)
                {
                    PlayerPrefs.SetInt("isOwnedH4", 1);
                    amountOfUnits++;
                    PlayerPrefs.SetInt("amountOfUnits", amountOfUnits);
                    isOwnedH4 = true;
                }
                else
                {
                    PlayerPrefs.SetInt("isOwnedH4", 0);
                    amountOfUnits--;
                    PlayerPrefs.SetInt("amountOfUnits", amountOfUnits);
                    isOwnedH4 = false;
                }
                PlayerPrefs.Save();
                break;
            case 5:
                if (owned)
                {
                    PlayerPrefs.SetInt("isOwnedH5", 1);
                    amountOfUnits++;
                    PlayerPrefs.SetInt("amountOfUnits", amountOfUnits);
                    isOwnedH5 = true;
                }
                else
                {
                    PlayerPrefs.SetInt("isOwnedH5", 0);
                    amountOfUnits--;
                    PlayerPrefs.SetInt("amountOfUnits", amountOfUnits);
                    isOwnedH5 = false;
                }
                PlayerPrefs.Save();
                break;
        }
    }

    public void UpdateHealtEffects(int which, int amount)
    {
        switch(which)
        {
            case 1:
                healthEffects1 += amount;
                PlayerPrefs.SetInt("HealingEffectsH1", healthEffects1);
                break;
            case 2:
                healthEffects2 += amount;
                PlayerPrefs.SetInt("HealingEffectsH2", healthEffects2);
                break;
            case 3:
                healthEffects3 += amount;
                PlayerPrefs.SetInt("HealingEffectsH3", healthEffects3);
                break;
            case 4:
                healthEffects4 += amount;
                PlayerPrefs.SetInt("HealingEffectsH4", healthEffects4);
                break;
            case 5:
                healthEffects5 += amount;
                PlayerPrefs.SetInt("HealingEffectsH5", healthEffects5);
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
