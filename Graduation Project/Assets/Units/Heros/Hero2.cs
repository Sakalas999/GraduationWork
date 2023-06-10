using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero2 : BaseHero
{
    public const string IsDeadH2 = "isDeaH2";
    public const string IsWoundedH2 = "isWoundedH2";
    private bool isWoundedH2 = false;
    public bool isDeadH2 = false;

    void Awake()
    {
        isWounded = isWoundedH2 = intToBool(PlayerPrefs.GetInt("isWoundedH2"));
        isDeadH2 = intToBool(PlayerPrefs.GetInt("isDeadH2"));
        BaseHealth += PlayerPrefs.GetInt("HealthEffectsH2") + PlayerPrefs.GetInt("HealthEffectsAll");
    }

    public void UpdateIsWounded(bool wounded)
    {
        if (wounded)
        {
            if (!isWoundedH2)
            {
                PlayerPrefs.SetInt("isWoundedH2", 1);
            }
            else
            {
                Kill();
            }
        }
        else
        {
            PlayerPrefs.SetInt("isWoundedH2", 0);
        }
        PlayerPrefs.Save();
    }

    public void Kill()
    {
        PlayerPrefs.SetInt("isDeadH2", 1);
        PlayerPrefs.SetInt("isOwnedH2", 0);
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
