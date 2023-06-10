using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            if (!isWoundedH1)
            {
                PlayerPrefs.SetInt("isWoundedH1", 1);
            }
            else
            {
                Kill();
            }
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
        PlayerPrefs.SetInt("isOwnedH1", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene(4);
    }

    private bool intToBool(int val)
    {
        if (val != 0)
            return true;
        else
            return false;
    }
}
