using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseRaid : MonoBehaviour
{
    public void Close()
    {
        GetComponentInParent<GameObject>().SetActive(false);
        PreventMultipleUi.Instance.isUIWindowOpen = false;
    }
}
