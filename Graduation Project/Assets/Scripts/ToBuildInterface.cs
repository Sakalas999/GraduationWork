using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToBuildInterface : MonoBehaviour
{
    [SerializeField]
    private GameObject _buildSlot;

    public void Build()
    {
        if (CurrencyManager.cheese >= 5)
        {
            this.gameObject.SetActive(false);
            BuildSlotManager.Instance.Build(_buildSlot);

            CurrencyManager.cheese += -5;
            CurrencyManager.UpdateCheese();
            MenuManager.Instance.UpdateCurrencyDisplay();
            PreventMultipleUi.Instance.isUIWindowOpen = false;    
        }
    }

    public void Close()
    {
        this.gameObject.SetActive(false);
        _buildSlot.SetActive(true);
        PreventMultipleUi.Instance.isUIWindowOpen = false;
    }
}
