using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero5 : BaseHero
{
    public const string IsDeadH5 = "isDeadH5";
    public const string IsWoundedH5 = "isWoundedH5";
    private bool isWoundedH5 = false;
    public bool isDeadH5 = false;

    void Awake()
    {
        isWounded = isWoundedH5 = intToBool(PlayerPrefs.GetInt("isWoundedH5"));
        isDeadH5 = intToBool(PlayerPrefs.GetInt("isDeadH5"));
        BaseHealth += PlayerPrefs.GetInt("HealthEffectsH5") + PlayerPrefs.GetInt("HealthEffectsAll");
    }

    public void UpdateIsWounded(bool wounded)
    {
        if (wounded)
        {
            if (!isWoundedH5)
            {
                PlayerPrefs.SetInt("isWoundedH5", 1);
            }
            else
            {
                Kill();
            }
        }
        else
        {
            PlayerPrefs.SetInt("isWoundedH5", 0);
        }
        PlayerPrefs.Save();
    }

    public void Kill()
    {
        PlayerPrefs.SetInt("isDeadH5", 1);
        PlayerPrefs.SetInt("isOwnedH5", 0);
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
