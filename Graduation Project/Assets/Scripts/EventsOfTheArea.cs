using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsOfTheArea : MonoBehaviour
{
    public GameObject[] events;

    public void GetARandomEvent()
    {
        int random = Random.Range(0, events.Length);

        if (InfoOnOwnedCharacters.Instance.isOwnedH2 || InfoOnOwnedCharacters.Instance.isDeadH2)
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

        if (InfoOnOwnedCharacters.Instance.isOwnedH3 || InfoOnOwnedCharacters.Instance.isDeadH3)
        {
            if (events[random].name == "CrossroadsEvent03")
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

        if (InfoOnOwnedCharacters.Instance.isOwnedH4 || InfoOnOwnedCharacters.Instance.isDeadH4)
        {
            if (events[random].name == "DeadEndEvent02")
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

        if (InfoOnOwnedCharacters.Instance.isOwnedH5 || InfoOnOwnedCharacters.Instance.isDeadH5)
        {
            if (events[random].name == "RatLairEvent04")
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
