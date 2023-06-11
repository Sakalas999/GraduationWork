using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEndEvent01 : MonoBehaviour
{
    private bool _failed;

    public void FirstChoice()
    {
        RandomChance();

        if (!_failed)
        {
            if ((InfoOnOwnedCharacters.Instance.isWoundedH1 || InfoOnOwnedCharacters.Instance.isWoundedH2 || InfoOnOwnedCharacters.Instance.isWoundedH3
               || InfoOnOwnedCharacters.Instance.isWoundedH4 || InfoOnOwnedCharacters.Instance.isWoundedH5))
            {
                RandomUnit();
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
        else
        {
            GetComponent<Event>().Choice01FailedCombat();
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
            InfoOnOwnedCharacters.Instance.UpdateWounded(random, false);
        else if (random == 2 && InfoOnOwnedCharacters.Instance.isOwnedH2)
            InfoOnOwnedCharacters.Instance.UpdateWounded(random, false);
        else if (random == 3 && InfoOnOwnedCharacters.Instance.isOwnedH3)
            InfoOnOwnedCharacters.Instance.UpdateWounded(random, false);
        else if (random == 4 && InfoOnOwnedCharacters.Instance.isOwnedH4)
            InfoOnOwnedCharacters.Instance.UpdateWounded(random, false);
        else if (random == 5 && InfoOnOwnedCharacters.Instance.isOwnedH5)
            InfoOnOwnedCharacters.Instance.UpdateWounded(random, false);
        else
            RandomUnit();
    }

    public void SecondChoice()
    {
        GetComponentInParent<Event>().Choice02();
    }

    public void Continue()
    {
        Map.Instance.loadingBattle = true;
        Map.Instance.characterSelectionWindow.SetActive(true);
        Map.Instance.characterSelectionWindow.GetComponent<CharacterSelection>().ShowSelection();

        int random = Random.Range(InfoOnOwnedCharacters.Instance.amountOfUnits,
            InfoOnOwnedCharacters.Instance.amountOfUnits + Mathf.RoundToInt((PlayerPrefs.GetInt("RaidChance") / 10)) + 2);

        int random1 = Random.Range(0, random);

        if (random1 < random)
        {
            int random2 = Random.Range(0, random - random1);

            if (random1 + random2 < random)
                InfoOnOwnedCharacters.Instance.AddEnemy(random, random1, random2, random - random1 - random2, 0, 0);
            else
                InfoOnOwnedCharacters.Instance.AddEnemy(random, random1, random2, 0, 0, 0);

        }
        else
            InfoOnOwnedCharacters.Instance.AddEnemy(random, random1, 0, 0, 0, 0);
        GetComponentInParent<Event>().CloseTheEvent();
        Map.Instance.eventOpen = true;
    }
}
