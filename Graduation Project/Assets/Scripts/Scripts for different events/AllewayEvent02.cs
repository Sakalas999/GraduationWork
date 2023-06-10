using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllewayEvent02 : MonoBehaviour
{
    public void FirstChoice()
    {
        CurrencyManager.cheese += 2 * PlayerPrefs.GetInt("CheeseMultiplier");
        CurrencyManager.UpdateCheese();
        MenuManager.Instance.UpdateCurrencyDisplay();
        GetComponentInParent<Event>().Choice01();

    }

    public void SecondChoice()
    {
        GetComponentInParent<Event>().Choice02();
    }
}
