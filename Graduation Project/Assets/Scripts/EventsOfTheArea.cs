using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsOfTheArea : MonoBehaviour
{
    public GameObject[] events;

    public void GetARandomEvent()
    {
        int random = Random.Range(0, events.Length);

        if (InfoOnOwnedCharacters.Instance.isOwnedH2)
        {
            if (events[random].name == "AlleywayEvent01")
            {
                GetARandomEvent();
            }
            else
            {
                events[random].SetActive(true);
            }
        }
        else
        {
            events[random].SetActive(true);
        }
    }
}
