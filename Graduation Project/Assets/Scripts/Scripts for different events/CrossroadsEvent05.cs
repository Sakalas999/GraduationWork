using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossroadsEvent05 : MonoBehaviour
{
    private bool _failed;
    public void FirstChoice()
    {
        RandomChance();

        if (!_failed)
        {
            CurrencyManager.cheese += 5 * PlayerPrefs.GetInt("CheeseMultiplier");
            CurrencyManager.UpdateCheese();

            MenuManager.Instance.UpdateCurrencyDisplay();

            GetComponentInParent<Event>().Choice01();
        }
        else
        {
            GetComponent<Event>().Choice01FailedCombat();
        }

        if (PlayerPrefs.GetInt("RaidChance") < 96)
            PlayerPrefs.SetInt("RaidChance", PlayerPrefs.GetInt("RaidChance") + 1);
    }

    public void SecondChoice()
    {
        GetComponentInParent<Event>().Choice02();
    }

    public void RandomChance()
    {
        int random = Random.Range(0, 10);
        int failChance = 4 + Mathf.RoundToInt((PlayerPrefs.GetInt("RaidChance") / 10));

        if (random <= failChance)
            _failed = true;
        else
            _failed = false;
    }

    public void Continue()
    {
        AudioManager.Instance.Play("Clicking");

        Map.Instance.loadingBattle = true;
        Map.Instance.characterSelectionWindow.SetActive(true);
        Map.Instance.characterSelectionWindow.GetComponent<CharacterSelection>().ShowSelection();

        int random = Random.Range(1,
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
