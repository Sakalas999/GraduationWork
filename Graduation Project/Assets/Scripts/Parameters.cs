using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parameters : MonoBehaviour
{
    public static Parameters Instance;

    void Awake()
    {
        Instance = this;   
    }

    public void SetAllParametersToDefault()
    {
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
        PlayerPrefs.SetInt("RaidLessPercentage", 0);

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

        PlayerPrefs.SetFloat("DamageEffectsH1", 1);
        PlayerPrefs.SetFloat("DamageEffectsH2", 1);
        PlayerPrefs.SetFloat("DamageEffectsH3", 1);
        PlayerPrefs.SetFloat("DamageEffectsH4", 1);
        PlayerPrefs.SetFloat("DamageEffectsH5", 1);

        PlayerPrefs.SetInt("cheese", 0);
        PlayerPrefs.SetInt("NewGameInitialised", 0);
        PlayerPrefs.SetInt("End Battle", 0);
        PlayerPrefs.SetInt("Raid", 0);
        PlayerPrefs.SetInt("RaidChance", 1);
        PlayerPrefs.Save();
    }
}
