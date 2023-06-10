using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatLairEvent01 : MonoBehaviour
{
    [SerializeField]
    private GameObject _characterSelection;

    public void FirstChoice()
    {
        GetComponentInParent<Event>().Choice01();
        PlayerPrefs.SetInt("RaidChance", PlayerPrefs.GetInt("RaidChance") + 5);
    }

    public void SecondChoice()
    {
        GetComponentInParent<Event>().Choice02More();
    }

    public void Continue()
    {
        _characterSelection.SetActive(true);
        _characterSelection.GetComponent<CharacterSelection>().ShowSelection();
        InfoOnOwnedCharacters.Instance.AddEnemy(2, 0, 2, 0);
        GetComponentInParent<Event>().CloseTheEvent();
        Map.Instance.eventOpen = true;
    }
}
