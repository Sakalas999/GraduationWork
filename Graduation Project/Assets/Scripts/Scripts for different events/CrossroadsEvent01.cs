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

            random = Random.Range(1, InfoOnOwnedCharacters.Instance.amountOfUnits);

            if (random == 1 && InfoOnOwnedCharacters.Instance.isOwnedH1)
                InfoOnOwnedCharacters.Instance.UpdateWounded(random, true);
            else if (random == 2 && InfoOnOwnedCharacters.Instance.isOwnedH2)
                InfoOnOwnedCharacters.Instance.UpdateWounded(random, true);
            else if (random != 2 && InfoOnOwnedCharacters.Instance.isOwnedH2)
                InfoOnOwnedCharacters.Instance.UpdateWounded(2, true);
            else
                GetComponentInParent<Event>().SomethingDidntWork();

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
