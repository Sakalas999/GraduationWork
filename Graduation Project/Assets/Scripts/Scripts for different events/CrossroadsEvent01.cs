using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossroadsEvent01 : MonoBehaviour
{
    public void FirstChoice()
    {
        int random;

        if (CurrencyManager.cheese >= 1)
        {
            if (CurrencyManager.cheese < 5)
                CurrencyManager.cheese += -CurrencyManager.cheese;
            else CurrencyManager.cheese += -5;
            CurrencyManager.UpdateCheese();

            RandomUnit();

            MenuManager.Instance.UpdateCurrencyDisplay();

            GetComponentInParent<Event>().Choice01();

            if (PlayerPrefs.GetInt("RaidChance") > 0)
                PlayerPrefs.SetInt("RaidChance", PlayerPrefs.GetInt("RaidChance") - 5);
        }
        else
        {
            GetComponentInParent<Event>().SomethingDidntWork();
            PlayerPrefs.SetInt("RaidChance", PlayerPrefs.GetInt("RaidChance") + 5);
        }
    }

    private void RandomUnit()
    {
        int random = Random.Range(1, 5);
        if (random == 1 && InfoOnOwnedCharacters.Instance.isOwnedH1)
            InfoOnOwnedCharacters.Instance.UpdateWounded(random, true);
        else if (random == 2 && InfoOnOwnedCharacters.Instance.isOwnedH2)
            InfoOnOwnedCharacters.Instance.UpdateWounded(random, true);
        else if (random == 3 && InfoOnOwnedCharacters.Instance.isOwnedH3)
            InfoOnOwnedCharacters.Instance.UpdateWounded(random, true);
        else if (random == 4 && InfoOnOwnedCharacters.Instance.isOwnedH4)
            InfoOnOwnedCharacters.Instance.UpdateWounded(random, true);
        else if (random == 5 && InfoOnOwnedCharacters.Instance.isOwnedH5)
            InfoOnOwnedCharacters.Instance.UpdateWounded(random, true);
        else
            RandomUnit();
    }

    public void SecondChoice()
    {
        GetComponentInParent<Event>().Choice02();
        PlayerPrefs.SetInt("RaidChance", PlayerPrefs.GetInt("RaidChance") + 5);
    }
}
