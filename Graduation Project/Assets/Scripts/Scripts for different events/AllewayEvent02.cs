using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllewayEvent02 : MonoBehaviour
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
    }

    public void SecondChoice()
    {
        GetComponentInParent<Event>().Choice02();
    }

    public void RandomChance()
    {
        int random = Random.Range(0, 10);
        int failChance = 5 + Mathf.RoundToInt((PlayerPrefs.GetInt("RaidChance") / 10));

        if (random <= failChance)
            _failed = true;
        else
            _failed = false;
    }

    public void Continue()
    {
        Map.Instance.loadingBattle = true;
        Map.Instance.characterSelectionWindow.SetActive(true);
        Map.Instance.characterSelectionWindow.GetComponent<CharacterSelection>().ShowSelection();

        int random = Random.Range(1,
           1 + Mathf.RoundToInt((PlayerPrefs.GetInt("RaidChance") / 10)) + 2);

        int random3 = Random.Range(0, 1);
        random -= random3;

        if (random > 0)
        {
            int random1 = Random.Range(0, random);
            random -= random1;

            if (random > 0)
            {
                int random2 = Random.Range(0, random);
                random -= random2;

                if (random > 0)
                    InfoOnOwnedCharacters.Instance.AddEnemy(random + random1 + random2 + random3, random1, random2, random, 0, random3);
                else
                    InfoOnOwnedCharacters.Instance.AddEnemy(random + random1 + random2 + random3, random1, random2, 0, 0, random3);
            }
            else
            {
                InfoOnOwnedCharacters.Instance.AddEnemy(random + random3 + random1, random1, 0, 0, 0, random3);
            }
        }
        else
            InfoOnOwnedCharacters.Instance.AddEnemy(random + random3, 0, 0, 0, 0, random3);
        GetComponentInParent<Event>().CloseTheEvent();
        Map.Instance.eventOpen = true;
    }
}
