using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreventMultipleUi : MonoBehaviour
{
    public static PreventMultipleUi Instance;
    public GameObject tipsDisplay;

    public bool isUIWindowOpen;
    private void Awake()
    {
        Instance = this;

        if (PlayerPrefs.GetInt("Raid") == 1)
        {
            isUIWindowOpen = true;
        }
        else
        {
            isUIWindowOpen = false;
        }
    }

    public void Tips()
    {
        AudioManager.Instance.Play("Clicking");

        if (!isUIWindowOpen)
        {
            tipsDisplay.SetActive(true);
            isUIWindowOpen = true;
        }
    }

    public void CloseTips()
    {
        tipsDisplay.SetActive(false);
        isUIWindowOpen = false;
    }
}
