using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiceTownEvent05 : MonoBehaviour
{
    private bool _failed;
    public void FirstChoice()
    {
        RandomChance();

        if (!_failed)
        {
            CurrencyManager.cheese += 1 * PlayerPrefs.GetInt("CheeseMultiplier");
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
        int failChance = 8 - InfoOnOwnedCharacters.Instance.amountOfUnits;

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

        int random = Random.Range(InfoOnOwnedCharacters.Instance.amountOfUnits,
            InfoOnOwnedCharacters.Instance.amountOfUnits + Mathf.RoundToInt((PlayerPrefs.GetInt("RaidChance") / 10))+2);

        InfoOnOwnedCharacters.Instance.AddEnemy(random, random, 0, 0, 0, 0);
        GetComponentInParent<Event>().CloseTheEvent();
        Map.Instance.eventOpen = true;
    }
}
