using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEndEvent01 : MonoBehaviour
{
    public void FirstChoice()
    {
        if (PlayerPrefs.GetInt("isWoundedH1") > 0)
        {
            InfoOnOwnedCharacters.Instance.UpdateWounded(1, false);
            GetComponentInParent<Event>().Choice01();
        }
        else if (PlayerPrefs.GetInt("isWoundedH2") > 0)
        {
            InfoOnOwnedCharacters.Instance.UpdateWounded(2, false);
            GetComponentInParent<Event>().Choice01();
        }
        else
        {
            CurrencyManager.cheese += 1 * PlayerPrefs.GetInt("CheeseMultiplier");
            CurrencyManager.UpdateCheese();
            MenuManager.Instance.UpdateCurrencyDisplay();

            GetComponentInParent<Event>().SomethingDidntWork();
        }

    }

    public void SecondChoice()
    {
        GetComponentInParent<Event>().Choice02();
    }
}
