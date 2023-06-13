using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour
{
    public GameObject[] eventAreas;
    public GameObject areYouSure;
    public GameObject tipsDisplay;
    public GameObject characterSelectionWindow;
    public bool eventOpen;
    public bool characterWindowOpen;
    public bool loadingBattle;

    public static Map Instance;

    void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && !eventOpen)
        {
            AudioManager.Instance.Play("Clicking");

            eventOpen = true;
            characterWindowOpen = true;
            characterSelectionWindow.SetActive(true);
            characterSelectionWindow.GetComponent<CharacterSelection>().ShowSelection();
        }
    }

    public void MiceTown()
    {
        AudioManager.Instance.Play("Clicking");

        if (eventOpen == false)
        {
            Debug.Log("Mice town location pressed");
            eventAreas[0].GetComponent<EventsOfTheArea>().GetARandomEvent();
            eventOpen = true;
        }
    }

    public void Crossroads()
    {
        AudioManager.Instance.Play("Clicking");

        if (eventOpen == false)
        {
            Debug.Log("Crossroads location pressed");
            eventAreas[1].GetComponent<EventsOfTheArea>().GetARandomEvent();
            eventOpen = true;
        }
    }

    public void DeadEnd()
    {
      AudioManager.Instance.Play("Clicking");

        if (eventOpen == false)
        {
            Debug.Log("DeadEnd location pressed");
            eventAreas[2].GetComponent<EventsOfTheArea>().GetARandomEvent();
            eventOpen = true;
        }
    }

    public void RatLair()
    {
        AudioManager.Instance.Play("Clicking");

        if (eventOpen == false)
        {
            Debug.Log("RatLair location pressed");
            eventAreas[3].GetComponent<EventsOfTheArea>().GetARandomEvent();
            eventOpen = true;
        }
    }

    public void Alleyway()
    {
        AudioManager.Instance.Play("Clicking");

        if (eventOpen == false)
        {
            Debug.Log("Alleyway location pressed");
            eventAreas[4].GetComponent<EventsOfTheArea>().GetARandomEvent();
            eventOpen = true;
        }
    }

    public void Base()
    {
        SceneManager.LoadScene(3);
    }

    public void EndBattle()
    {
        AudioManager.Instance.Play("Clicking");

        areYouSure.SetActive(true);
        eventOpen = true;
    }

    public void Tips()
    {
        AudioManager.Instance.Play("Clicking");

        if (!eventOpen)
        {
            tipsDisplay.SetActive(true);
            eventOpen = true;
        }
    }

    public void CloseTips()
    {
        tipsDisplay.SetActive(false);
        eventOpen = false;
    }
}
