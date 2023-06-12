using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatLairEvent05 : MonoBehaviour
{
    public void FirstChoice()
    {
        GetComponentInParent<Event>().Choice01More();

        if (PlayerPrefs.GetInt("RaidChance") > 1)
            PlayerPrefs.SetInt("RaidChance", PlayerPrefs.GetInt("RaidChance") - 1);
    }

    public void SecondChoice()
    {
        GetComponentInParent<Event>().Choice02More();
        if (PlayerPrefs.GetInt("RaidChance") < 96)
            PlayerPrefs.SetInt("RaidChance", PlayerPrefs.GetInt("RaidChance") - 1);
    }

    public void Continue()
    {
        Map.Instance.loadingBattle = true;
        Map.Instance.characterSelectionWindow.SetActive(true);
        Map.Instance.characterSelectionWindow.GetComponent<CharacterSelection>().ShowSelection();

        int random = Random.Range(1,
           1 + Mathf.RoundToInt((PlayerPrefs.GetInt("RaidChance") / 10)) + 2);

        InfoOnOwnedCharacters.Instance.AddEnemy(random, random, 0, 0, 0, 0);
        GetComponentInParent<Event>().CloseTheEvent();
        Map.Instance.eventOpen = true;
    }
}
