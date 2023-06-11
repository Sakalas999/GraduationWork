using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlleywayEvent03 : MonoBehaviour
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
            PlayerPrefs.SetInt("RaidChance", PlayerPrefs.GetInt("RaidChance") + 1);
    }

    public void Continue()
    {
        Map.Instance.loadingBattle = true;
        Map.Instance.characterSelectionWindow.SetActive(true);
        Map.Instance.characterSelectionWindow.GetComponent<CharacterSelection>().ShowSelection();

        int random = Random.Range(0, 1);

        InfoOnOwnedCharacters.Instance.AddEnemy(1 + random, 0, 0, 0, random, 1);
        GetComponentInParent<Event>().CloseTheEvent();
        Map.Instance.eventOpen = true;
    }
}
