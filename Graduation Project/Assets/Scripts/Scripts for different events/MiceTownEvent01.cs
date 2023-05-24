using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiceTownEvent01 : MonoBehaviour
{
    public void FirstChoice()
    {
        if (CurrencyManager.cheese >= 5)
        {
            CurrencyManager.cheese += -5;
            CurrencyManager.UpdateCheese();

            MenuManager.Instance.UpdateCurrencyDisplay();


            GetComponentInParent<Event>().Choice01();
        }
        else
        {
            GetComponentInParent<Event>().SomethingDidntWork();
        }
    }

    public void SecondChoice()
    {
        GetComponentInParent<Event>().Choice02();
    }
}
