using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero4 : BaseHero
{
    public const string IsDeadH4 = "isDeadH4";
    public const string IsWoundedH4 = "isWoundedH4";
    private bool isWoundedH4 = false;
    public bool isDeadH4 = false;

    void Awake()
    {
        isWounded = isWoundedH4 = intToBool(PlayerPrefs.GetInt("isWoundedH4"));
        isDeadH4 = intToBool(PlayerPrefs.GetInt("isDeadH4"));
        BaseHealth += PlayerPrefs.GetInt("HealthEffectsH4") + PlayerPrefs.GetInt("HealthEffectsAll");
    }

    public void UpdateIsWounded(bool wounded)
    {
        if (wounded)
        {
            if (!isWoundedH4)
            {
                PlayerPrefs.SetInt("isWoundedH4", 1);
            }
            else
            {
                Kill();
            }
        }
        else
        {
            PlayerPrefs.SetInt("isWoundedH4", 0);
        }
        PlayerPrefs.Save();
    }

    public void Kill()
    {
        PlayerPrefs.SetInt("isDeadH4", 1);
        PlayerPrefs.SetInt("isOwnedH4", 0);
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
