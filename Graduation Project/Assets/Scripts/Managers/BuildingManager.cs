using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Instance;
    public bool isABuilt, isGBuilt, isHHBuilt, isSHBuilt, isCSBuilt;

    public int ALevel, GLevel, HHLevel, SHLevel, CSLevel;

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
        PlayerPrefs.SetInt("HHLevel", 0);
        PlayerPrefs.SetInt("SHLevel", 0);
        PlayerPrefs.SetInt("CSLevel", 0);
    }

    public void UpgradeBuilding(string initialOfBuilding)
    {
        if (initialOfBuilding == "A")
        {
            ALevel++;
            PlayerPrefs.SetInt("ALevel", ALevel);
        }
        if (initialOfBuilding == "G")
        {
            GLevel++;
            PlayerPrefs.SetInt("GLevel", GLevel);
        }
        if (initialOfBuilding == "HH")
        {
            HHLevel++;
            PlayerPrefs.SetInt("HHLevel", HHLevel);
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
        }
    }

    public void DecreseBuilding(string initialOfBuilding)
    {
        if (initialOfBuilding == "A")
        {
            ALevel--;
            PlayerPrefs.SetInt("ALevel", ALevel);
        }
        if (initialOfBuilding == "G")
        {
            GLevel--;
            PlayerPrefs.SetInt("GLevel", GLevel);
        }
        if (initialOfBuilding == "HH")
        {
            HHLevel--;
            PlayerPrefs.SetInt("HHLevel", HHLevel);
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
        }
    }
}
