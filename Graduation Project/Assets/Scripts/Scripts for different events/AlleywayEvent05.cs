using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlleywayEvent05 : MonoBehaviour
{
    public void FirstChoice()
    {
        if (CurrencyManager.cheese >= 1 * PlayerPrefs.GetInt("CheeseMultiplier"))
        {
            CurrencyManager.cheese -= 1 * PlayerPrefs.GetInt("CheeseMultiplier");
            CurrencyManager.UpdateCheese();

            MenuManager.Instance.UpdateCurrencyDisplay();

            GetComponentInParent<Event>().Choice01();
            if (PlayerPrefs.GetInt("RaidChance") > 1)
                PlayerPrefs.SetInt("RaidChance", PlayerPrefs.GetInt("RaidChance") - 1);
        }
        else
            GetComponentInParent<Event>().SomethingDidntWork();
    }

    public void SecondChoice()
    {
        GetComponentInParent<Event>().Choice02();
        if (PlayerPrefs.GetInt("RaidChance") < 96)
            PlayerPrefs.SetInt("RaidChance", PlayerPrefs.GetInt("RaidChance") + 1);
    }
}
