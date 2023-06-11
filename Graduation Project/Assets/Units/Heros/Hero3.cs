using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero3 : BaseHero
{
    public const string IsDeadH3 = "isDeadH3";
    public const string IsWoundedH3 = "isWoundedH3";
    private bool isWoundedH3 = false;
    public bool isDeadH3 = false;

    void Awake()
    {
        isWounded = isWoundedH3 = intToBool(PlayerPrefs.GetInt("isWoundedH3"));
        isDeadH3 = intToBool(PlayerPrefs.GetInt("isDeadH3"));
        BaseHealth += PlayerPrefs.GetInt("HealthEffectsH3") + PlayerPrefs.GetInt("HealthEffectsAll");
    }

    public void UpdateIsWounded(bool wounded)
    {
        if (wounded)
        {
            if (!isWoundedH3)
            {
                PlayerPrefs.SetInt("isWoundedH3", 1);
            }
            else
            {
                Kill();
            }
        }
        else
        {
            PlayerPrefs.SetInt("isWoundedH3", 0);
        }
        PlayerPrefs.Save();
    }

    public void Kill()
    {
        PlayerPrefs.SetInt("isDeadH3", 1);
        PlayerPrefs.SetInt("isOwnedH3", 0);
        PlayerPrefs.Save();
    }

    private bool intToBool(int val)
    {
        if (val != 0)
            return true;
        else
            return false;
    }
}
