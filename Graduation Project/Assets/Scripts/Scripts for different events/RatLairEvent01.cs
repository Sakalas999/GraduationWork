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

        int random = Random.Range(1,
           1 + Mathf.RoundToInt((PlayerPrefs.GetInt("RaidChance") / 10)) + 2);

        int random1 = Random.Range(0, random);
        random -= random1;

        if  (random > 0)
        {         
            InfoOnOwnedCharacters.Instance.AddEnemy(random+random1, 0, random1, random, 0, 0);                   
        }
        else
            InfoOnOwnedCharacters.Instance.AddEnemy(random, 0, random1, 0, 0, 0);
        GetComponentInParent<Event>().CloseTheEvent();
        Map.Instance.eventOpen = true;
    }
}
