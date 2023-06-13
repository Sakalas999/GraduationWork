using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEndEvent04 : MonoBehaviour
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
            RandomUnitNegative();
            GetComponentInParent<Event>().Choice01Failed();
        }
    }

    public void RandomChance()
    {
        int random = Random.Range(0, 10);
        int failChance = 5;

        if (random <= failChance)
            _failed = true;
        else
            _failed = false;
    }

    private void RandomUnit()
    {
        int random = Random.Range(1, 5);
        if (random == 1 && InfoOnOwnedCharacters.Instance.isOwnedH1)
            InfoOnOwnedCharacters.Instance.UpdateHealtEffects(random, 5);
        else if (random == 2 && InfoOnOwnedCharacters.Instance.isOwnedH2)
            InfoOnOwnedCharacters.Instance.UpdateHealtEffects(random, 5);
        else if (random == 3 && InfoOnOwnedCharacters.Instance.isOwnedH3)
            InfoOnOwnedCharacters.Instance.UpdateHealtEffects(random, 5);
        else if (random == 4 && InfoOnOwnedCharacters.Instance.isOwnedH4)
            InfoOnOwnedCharacters.Instance.UpdateHealtEffects(random, 5);
        else if (random == 5 && InfoOnOwnedCharacters.Instance.isOwnedH5)
            InfoOnOwnedCharacters.Instance.UpdateHealtEffects(random, 5);
        else
            RandomUnit();
    }

    private void RandomUnitNegative()
    {
        int random = Random.Range(1, 5);
        if (random == 1 && InfoOnOwnedCharacters.Instance.isOwnedH1)
            InfoOnOwnedCharacters.Instance.UpdateWounded(random, true);
        else if (random == 2 && InfoOnOwnedCharacters.Instance.isOwnedH2)
            InfoOnOwnedCharacters.Instance.UpdateWounded(random, true);
        else if (random == 3 && InfoOnOwnedCharacters.Instance.isOwnedH3)
            InfoOnOwnedCharacters.Instance.UpdateWounded(random, true);
        else if (random == 4 && InfoOnOwnedCharacters.Instance.isOwnedH4)
            InfoOnOwnedCharacters.Instance.UpdateWounded(random, true);
        else if (random == 5 && InfoOnOwnedCharacters.Instance.isOwnedH5)
            InfoOnOwnedCharacters.Instance.UpdateWounded(random, true);
        else
            RandomUnitNegative();
    }

    public void SecondChoice()
    {
        GetComponentInParent<Event>().Choice02();
    }
}
