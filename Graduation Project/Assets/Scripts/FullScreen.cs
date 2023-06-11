using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullScreen : MonoBehaviour
{
    [SerializeField] private Toggle _toggle;

    private void Awake()
    {
        if (Screen.fullScreen)
            _toggle.isOn = true;
        else
            _toggle.isOn = false;
        
    }

    public void SetFullScreen(bool isFullScreen)
    { 
        Screen.fullScreen = isFullScreen;
    }
}
