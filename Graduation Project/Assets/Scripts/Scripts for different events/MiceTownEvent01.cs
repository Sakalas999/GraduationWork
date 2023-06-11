using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiceTownEvent01 : MonoBehaviour
{
    private bool _failed;
    public void FirstChoice()
    {
        RandomChance();

        if (_failed)
        {


            if (CurrencyManager.cheese >= 1 * PlayerPrefs.GetInt("CheeseMultiplier"))
            {
                CurrencyManager.cheese -= 1 * PlayerPrefs.GetInt("CheeseMultiplier");
                CurrencyManager.UpdateCheese();

                MenuManager.Instance.UpdateCurrencyDisplay();

                RandomUnit();

                GetComponentInParent<Event>().Choice01();
            }
            else
            {
                GetComponentInParent<Event>().SomethingDidntWork();
            }
        }
        else
        {
            if (CurrencyManager.cheese >= 1 * PlayerPrefs.GetInt("CheeseMultiplier"))
            {
                CurrencyManager.cheese -= 1 * PlayerPrefs.GetInt("CheeseMultiplier");
                CurrencyManager.UpdateCheese();

                MenuManager.Instance.UpdateCurrencyDisplay();
                GetComponentInParent<Event>().Choice01Failed();
            }
            else
            {
                GetComponentInParent<Event>().SomethingDidntWork();
            }
        }
    }

    public void RandomChance()
    {
        int random = Random.Range(0, 10);
        int failChance = 5;

        if (random <= failChance)
            _failed = true;
        else
            _failed = false;
    }

    private void RandomUnit()
    {
        int random = Random.Range(1, 5);
        if (random == 1 && InfoOnOwnedCharacters.Instance.isOwnedH1)
            InfoOnOwnedCharacters.Instance.UpdateDamageEffects(random, 0.1f);
        else if (random == 2 && InfoOnOwnedCharacters.Instance.isOwnedH2)
            InfoOnOwnedCharacters.Instance.UpdateDamageEffects(random, 0.1f);
        else if (random == 3 && InfoOnOwnedCharacters.Instance.isOwnedH3)
            InfoOnOwnedCharacters.Instance.UpdateDamageEffects(random, 0.1f);
        else if (random == 4 && InfoOnOwnedCharacters.Instance.isOwnedH4)
            InfoOnOwnedCharacters.Instance.UpdateDamageEffects(random, 0.1f);
        else if (random == 5 && InfoOnOwnedCharacters.Instance.isOwnedH5)
            InfoOnOwnedCharacters.Instance.UpdateDamageEffects(random, 0.1f);
        else
            RandomUnit();
    }

    public void SecondChoice()
    {
        GetComponentInParent<Event>().Choice02();
    }
}
