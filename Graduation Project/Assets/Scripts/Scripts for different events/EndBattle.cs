using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBattle : MonoBehaviour
{
    [SerializeField] private GameObject characterSelectionWindow;

    public void Yes()
    {
        AudioManager.Instance.Play("Clicking");

        this.gameObject.SetActive(false);

        characterSelectionWindow.SetActive(true);
        characterSelectionWindow.GetComponent<CharacterSelection>().ShowSelection();

        InfoOnOwnedCharacters.Instance.AddEnemy(2, 0, 0, 0, 1, 1);

        PlayerPrefs.SetInt("End Battle", 1);
        PlayerPrefs.Save();
    }

    public void No()
    {
        this.gameObject.SetActive(false);
        Map.Instance.eventOpen = false;
    }
}
