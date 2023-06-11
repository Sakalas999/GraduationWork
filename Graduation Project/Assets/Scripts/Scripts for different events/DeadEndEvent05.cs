using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEndEvent05 : MonoBehaviour
{
    private bool _failed;
    public void FirstChoice()
    {
        RandomChance();

        if (!_failed)
        {
                RandomUnit();
                GetComponentInParent<Event>().Choice01();          
        }
        else
        {       
                GetComponentInParent<Event>().Choice01FailedCombat();          
        }
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

    private void RandomUnit()
    {
        int random = Random.Range(1, 5);
        if (random == 1 && InfoOnOwnedCharacters.Instance.isOwnedH1)
            InfoOnOwnedCharacters.Instance.UpdateDamageEffects(random, 0.1f);
        else if (random == 2 && InfoOnOwnedCharacters.Instance.isOwnedH2)
            InfoOnOwnedCharacters.Instance.UpdateDamageEffects(random, 0.1f);
        else if (random == 3 && InfoOnOwnedCharacters.Instance.isOwnedH3)
            InfoOnOwnedCharacters.Instance.UpdateDamageEffects(random, 0.1f);
        else if (random == 4 && InfoOnOwnedCharacters.Instance.isOwnedH4)
            InfoOnOwnedCharacters.Instance.UpdateDamageEffects(random, 0.1f);
        else if (random == 5 && InfoOnOwnedCharacters.Instance.isOwnedH5)
            InfoOnOwnedCharacters.Instance.UpdateDamageEffects(random, 0.1f);
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

        InfoOnOwnedCharacters.Instance.AddEnemy(random, random, 0, 0, 0, 0);
        GetComponentInParent<Event>().CloseTheEvent();
        Map.Instance.eventOpen = true;
    }
}
