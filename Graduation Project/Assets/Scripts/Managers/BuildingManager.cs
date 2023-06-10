using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Instance;
    public bool isABuilt, isGBuilt, isHHBuilt, isSHBuilt, isCSBuilt;

    public int ALevel, GLevel, SHLevel, CSLevel;

    void Awake()
    {
        Instance = this;

        /*CurrencyManager.cheese = 100;
        CurrencyManager.UpdateCheese();
        MenuManager.Instance.UpdateCurrencyDisplay();

        PlayerPrefs.SetInt("isABuilt", 0);
        PlayerPrefs.SetInt("isGBuilt", 0);
        PlayerPrefs.SetInt("isHHBuilt", 0);
        PlayerPrefs.SetInt("isSHBuilt", 0);
        PlayerPrefs.SetInt("isCSBuilt", 0);

        PlayerPrefs.SetInt("ALevel", 0);
        PlayerPrefs.SetInt("GLevel", 0);
        PlayerPrefs.SetInt("SHLevel", 0);
        PlayerPrefs.SetInt("CSLevel", 0);

        PlayerPrefs.SetInt("HealthEffectsAll", 0);
        PlayerPrefs.SetInt("DamageEffectsAll", 0);
        PlayerPrefs.SetInt("CheeseMultiplier", 1);
        PlayerPrefs.SetInt("RaidLessPercentage", 0);*/

        if (PlayerPrefs.GetInt("isABuilt") != 0)
        {
            isABuilt = true;
            ALevel = PlayerPrefs.GetInt("ALevel");
        }
        else
        {
            isABuilt = false;
        }

        if (PlayerPrefs.GetInt("isGBuilt") != 0)
        {
            isGBuilt = true;
            GLevel = PlayerPrefs.GetInt("GLevel");
        }
        else
        {
            isGBuilt = false;
        }

        if (PlayerPrefs.GetInt("isHHBuilt") != 0)
        {
            isHHBuilt = true;
        }
        else
        {
            isHHBuilt = false;
        }

        if (PlayerPrefs.GetInt("isSHBuilt") != 0)
        {
            isSHBuilt = true;
            SHLevel = PlayerPrefs.GetInt("SHLevel");
        }
        else
        {
            isSHBuilt = false;
        }

        if (PlayerPrefs.GetInt("isCSBuilt") != 0)
        {
            isCSBuilt = true;
            CSLevel = PlayerPrefs.GetInt("CSLevel");
        }
        else
        {
            isCSBuilt = false;
        }
    }

    public void UpgradeBuilding(string initialOfBuilding)
    {
        if (initialOfBuilding == "A")
        {
            ALevel++;
            PlayerPrefs.SetInt("ALevel", ALevel);
            PlayerPrefs.SetInt("DamageEffectsAll", ALevel * 5);
            PlayerPrefs.Save();
        }
        if (initialOfBuilding == "G")
        {
            GLevel++;
            PlayerPrefs.SetInt("GLevel", GLevel);
            PlayerPrefs.SetInt("HealthEffectsAll", GLevel * 50);
            PlayerPrefs.Save();
        }
        if (initialOfBuilding == "SH")
        {
            SHLevel++;
            PlayerPrefs.SetInt("SHLevel", SHLevel);
            PlayerPrefs.SetInt("RaidLessPercentage", SHLevel * 5);
            PlayerPrefs.Save();
        }
        if (initialOfBuilding == "CS")
        {
            CSLevel++;
            PlayerPrefs.SetInt("CSLevel", CSLevel);
            PlayerPrefs.SetInt("CheeseMultiplier", CSLevel + 1);
            PlayerPrefs.Save();
        }
    }

    public void DecreseBuilding(string initialOfBuilding)
    {
        if (initialOfBuilding == "A")
        {
            ALevel--;
            if (ALevel < 1)
            {
                PlayerPrefs.SetInt("ALevel", ALevel);
                PlayerPrefs.SetInt("isABuilt", 0);
                PlayerPrefs.SetInt("DamageEffectsAll", ALevel);
                PlayerPrefs.Save();

                isABuilt = false;
            }
            else
            {
                PlayerPrefs.SetInt("ALevel", ALevel);
                PlayerPrefs.SetInt("DamageEffectsAll", ALevel * 5);
                PlayerPrefs.Save();
            }
        }
        if (initialOfBuilding == "G")
        {
            GLevel--;
            if (GLevel < 1)
            {
                PlayerPrefs.SetInt("isGBuilt", 0);
                PlayerPrefs.SetInt("GLevel", GLevel);
                PlayerPrefs.SetInt("HealthEffectsAll", GLevel * 50);
                PlayerPrefs.Save();

                isGBuilt = false;
            }
            else
            {
                PlayerPrefs.SetInt("GLevel", GLevel);
                PlayerPrefs.SetInt("HealthEffectsAll", GLevel * 50);
                PlayerPrefs.Save();
            }
        }
        if (initialOfBuilding == "SH")
        {
            SHLevel--;
            if (SHLevel < 1)
            {
                PlayerPrefs.SetInt("isSHBuilt", 0);
                PlayerPrefs.SetInt("SHLevel", SHLevel);
                PlayerPrefs.SetInt("RaidLessPercentage", SHLevel * 5);
                PlayerPrefs.Save();

                isSHBuilt = false;
            }
            else
            {
                PlayerPrefs.SetInt("SHLevel", SHLevel);
                PlayerPrefs.SetInt("RaidLessPercentage", SHLevel * 5);
                PlayerPrefs.Save();
            }
        }
        if (initialOfBuilding == "CS")
        {
            CSLevel--;

            if (CSLevel < 1)
            {
                PlayerPrefs.SetInt("isCSBuilt", 0);
                isCSBuilt = false;

                PlayerPrefs.SetInt("CheeseMultiplier", 1);
                PlayerPrefs.SetInt("CSLevel", CSLevel);
                PlayerPrefs.Save();

            }
            else
            {
                PlayerPrefs.SetInt("CSLevel", CSLevel);
                PlayerPrefs.SetInt("CheeseMultiplier", CSLevel + 1);
                PlayerPrefs.Save();
            }
        }
    }
}
