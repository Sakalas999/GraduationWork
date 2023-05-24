using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsOfTheArea : MonoBehaviour
{
    public GameObject[] events;

    public void GetARandomEvent()
    {
        int random = Random.Range(0, events.Length);
        events[random].SetActive(true);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
