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
    }

    public void UpdateIsWounded(bool wounded)
    {
        if (wounded)
        {
            PlayerPrefs.SetInt("isWoundedH2", 1);
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
