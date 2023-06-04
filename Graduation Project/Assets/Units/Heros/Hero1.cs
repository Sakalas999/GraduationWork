using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero1 : BaseHero
{
    public const string IsDeadH1 = "isDeadH1";
    public const string IsWoundedH1 = "isWoundedH1";
    private bool isWoundedH1 = false;
    public bool isDeadH1 = false;

    void Awake()
    {
        isWounded = isWoundedH1 = intToBool(PlayerPrefs.GetInt("isWoundedH1"));
        isDeadH1 = intToBool(PlayerPrefs.GetInt("isDeadH1"));

        BaseHealth += PlayerPrefs.GetInt("HealthEffectsH1") + PlayerPrefs.GetInt("HealthEffectsAll");
    }
    public void UpdateIsWounded(bool wounded)
    {
        if (wounded)
        {
            PlayerPrefs.SetInt("isWoundedH1", 1);
        }
        else
        {
            PlayerPrefs.SetInt("isWoundedH1", 0);
        }
        PlayerPrefs.Save();
    }

    public void Kill()
    {
        PlayerPrefs.SetInt("isDeadH1", 1);
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
