using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsOfTheArea : MonoBehaviour
{
    public GameObject[] events;
    public GameObject[] deletable;

    private void Start()
    {
        if (InfoOnOwnedCharacters.Instance.isOwnedH2 || InfoOnOwnedCharacters.Instance.isDeadH2)
            DestroyObject(deletable[0]);
        if (InfoOnOwnedCharacters.Instance.isOwnedH3 || InfoOnOwnedCharacters.Instance.isDeadH3)
            DestroyObject(deletable[1]);
        if (InfoOnOwnedCharacters.Instance.isOwnedH4 || InfoOnOwnedCharacters.Instance.isDeadH4)
            DestroyObject(deletable[2]);
        if (InfoOnOwnedCharacters.Instance.isOwnedH5 || InfoOnOwnedCharacters.Instance.isDeadH5)
            DestroyObject(deletable[3]);
    }

    public void GetARandomEvent()
    {
        int random = Random.Range(0, events.Length);

        if (events[random] == null)
        {
            GetARandomEvent();
        }
        else
        {
            events[random].SetActive(true);
        }      
    }
}
