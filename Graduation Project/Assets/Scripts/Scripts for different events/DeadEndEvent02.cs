using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEndEvent02 : MonoBehaviour
{
    public void FirstChoice()
    {
        if (CurrencyManager.cheese >= 1 * PlayerPrefs.GetInt("CheeseMultiplier"))
        {
            CurrencyManager.cheese -= 1 * PlayerPrefs.GetInt("CheeseMultiplier");
            CurrencyManager.UpdateCheese();
            MenuManager.Instance.UpdateCurrencyDisplay();

            InfoOnOwnedCharacters.Instance.UpdateOwned(4, true);
            GetComponentInParent<Event>().Choice01();
        }
        else
            GetComponentInParent<Event>().SomethingDidntWork();

    }

    public void SecondChoice()
    {
        GetComponentInParent<Event>().Choice02();
    }
}
