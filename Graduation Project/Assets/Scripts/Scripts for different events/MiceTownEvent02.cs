using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiceTownEvent02 : MonoBehaviour
{
    private bool _gotCheese;

    public void FirstChoice()
    {
        RandomChance();

        if (_gotCheese)
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
        int failChance = 3 + Mathf.RoundToInt((PlayerPrefs.GetInt("RaidChance") / 10));

        if (random <= failChance)
            _gotCheese = false;
        else
            _gotCheese = true;
    }

    public void Continue()
    {
        AudioManager.Instance.Play("Clicking");

        Map.Instance.loadingBattle = true;
        Map.Instance.characterSelectionWindow.SetActive(true);
        Map.Instance.characterSelectionWindow.GetComponent<CharacterSelection>().ShowSelection();

        int random = Random.Range(1,
            1 + Mathf.RoundToInt((PlayerPrefs.GetInt("RaidChance") / 10))+2);

        InfoOnOwnedCharacters.Instance.AddEnemy(random, random, 0, 0, 0, 0);
        GetComponentInParent<Event>().CloseTheEvent();
        Map.Instance.eventOpen = true;
    }
}
