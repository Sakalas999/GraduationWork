using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreventMultipleUi : MonoBehaviour
{
    public static PreventMultipleUi Instance;

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
}
