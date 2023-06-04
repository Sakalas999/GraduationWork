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
    }

    public void UpgradeBuilding(string initialOfBuilding)
    {
        if (initialOfBuilding == "A")
        {
            ALevel++;
            PlayerPrefs.SetInt("ALevel", ALevel);
            PlayerPrefs.SetInt("DamageEffectsAll", ALevel * 10);
        }
        if (initialOfBuilding == "G")
        {
            GLevel++;
            PlayerPrefs.SetInt("GLevel", GLevel);
            PlayerPrefs.SetInt("HealthEffectsAll", GLevel * 50);
        }
        if (initialOfBuilding == "SH")
        {
            SHLevel++;
            PlayerPrefs.SetInt("SHLevel", SHLevel);
        }
        if (initialOfBuilding == "CS")
        {
            CSLevel++;
            PlayerPrefs.SetInt("CSLevel", CSLevel);
            PlayerPrefs.SetInt("CheeseMultiplier", CSLevel);
        }
    }

    public void DecreseBuilding(string initialOfBuilding)
    {
        if (initialOfBuilding == "A")
        {
            ALevel--;
            PlayerPrefs.SetInt("ALevel", ALevel);
            PlayerPrefs.SetInt("DamageEffectsAll", ALevel * 10);
        }
        if (initialOfBuilding == "G")
        {
            GLevel--;
            PlayerPrefs.SetInt("GLevel", GLevel);
            PlayerPrefs.SetInt("HealthEffectsAll", GLevel * 50);
        }
        if (initialOfBuilding == "SH")
        {
            SHLevel--;
            PlayerPrefs.SetInt("SHLevel", SHLevel);
        }
        if (initialOfBuilding == "CS")
        {
            CSLevel--;
            PlayerPrefs.SetInt("CSLevel", CSLevel);

            if (CSLevel > 0)
            {
                PlayerPrefs.SetInt("CheeseMultiplier", CSLevel);
            }
            else
            {
                PlayerPrefs.SetInt("CheeseMultiplier", 1);
            }
        }
    }
}
