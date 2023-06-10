using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Event : MonoBehaviour
{
    public GameObject[] texts;
    public GameObject[] buttons;

    public void Choice01()
    {
        texts[0].SetActive(false);
        texts[1].SetActive(true);

        buttons[0].SetActive(false);
        buttons[1].SetActive(false);
        buttons[2].SetActive(true);

    }

    public void Choice02()
    {
        texts[0].SetActive(false);
        texts[2].SetActive(true);

        buttons[0].SetActive(false);
        buttons[1].SetActive(false);
        buttons[2].SetActive(true);
    }

    public void Choice02More()
    {
        texts[0].SetActive(false);
        texts[2].SetActive(true);

        buttons[0].SetActive(false);
        buttons[1].SetActive(false);
        buttons[3].SetActive(true);
    }

    public void CloseTheEvent()
    {
        buttons[2].transform.parent.gameObject.SetActive(false);
        buttons[0].SetActive(true);
        buttons[1].SetActive(true);
        buttons[2].SetActive(false);

        texts[0].SetActive(true);
        texts[1].SetActive(false);
        texts[2].SetActive(false);

        if (texts.Length > 3 && texts[3] != null)
        texts[3].SetActive(false);

        Map.Instance.eventOpen = false;

        RaidChance();
        if (PlayerPrefs.GetInt("Raid") == 1)
            SceneManager.LoadScene(3);
    }

    public void SomethingDidntWork()
    {
        texts[0].SetActive(false);
        texts[3].SetActive(true);

        buttons[0].SetActive(false);
        buttons[1].SetActive(false);
        buttons[2].SetActive(true);
    }

      private void RaidChance()
    {
        int random = Random.Range(0, 100);
        random -= PlayerPrefs.GetInt("RaidLessPercentage");

        if (random >= 0 && random < PlayerPrefs.GetInt("RaidChance"))
        {
            PlayerPrefs.SetInt("Raid", 1);
            PlayerPrefs.Save();
        }
    }
}
