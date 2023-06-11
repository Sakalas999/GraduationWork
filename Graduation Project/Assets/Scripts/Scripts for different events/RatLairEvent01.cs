using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatLairEvent01 : MonoBehaviour
{
    [SerializeField]
    private GameObject _characterSelection;

    public void FirstChoice()
    {
        GetComponentInParent<Event>().Choice01More();

        if (PlayerPrefs.GetInt("RaidChance") < 96)
            PlayerPrefs.SetInt("RaidChance", PlayerPrefs.GetInt("RaidChance") + 1);
    }

    public void SecondChoice()
    {
        GetComponentInParent<Event>().Choice02More();
    }

    public void Continue()
    {
        Map.Instance.loadingBattle = true;
        _characterSelection.SetActive(true);
        _characterSelection.GetComponent<CharacterSelection>().ShowSelection();

        int random = Random.Range(InfoOnOwnedCharacters.Instance.amountOfUnits,
           InfoOnOwnedCharacters.Instance.amountOfUnits + Mathf.RoundToInt((PlayerPrefs.GetInt("RaidChance") / 10)) + 2);

        int random1 = Random.Range(0, random);

        if (random1 < random)
        {
            int random2 = Random.Range(0, random - random1);           
            InfoOnOwnedCharacters.Instance.AddEnemy(random, 0, random1, random2, 0, 0);                   
        }
        else
            InfoOnOwnedCharacters.Instance.AddEnemy(random, 0, random1, 0, 0, 0);
        GetComponentInParent<Event>().CloseTheEvent();
        Map.Instance.eventOpen = true;
    }
}
