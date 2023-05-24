using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiceTownEvent02 : MonoBehaviour
{
    public void FirstChoice()
    {
        CurrencyManager.cheese += 5;
        CurrencyManager.UpdateCheese();

        MenuManager.Instance.UpdateCurrencyDisplay();


        GetComponentInParent<Event>().Choice01();
    }

    public void SecondChoice()
    {
        GetComponentInParent<Event>().Choice02();
    }
}
