using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlleywayEvent01 : MonoBehaviour
{
    public void FirstChoice()
    {
        InfoOnOwnedCharacters.Instance.UpdateOwned(2, true);
        GetComponentInParent<Event>().Choice01();

    }

    public void SecondChoice()
    {
        GetComponentInParent<Event>().Choice02();
    }
}
