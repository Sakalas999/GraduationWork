using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuildingsInterfaces : MonoBehaviour
{
    private GameObject _currentInterface;

    [SerializeField]
    private GameObject _mainText, _heal, _upgrade;

    private void Start()
    {
        _currentInterface = this.gameObject;
    }

    public void UpdateMainText(string text)
    {
        _mainText.GetComponent<TextMeshProUGUI>().text = text;
    }

    public void HideUpgrade()
    {
        _upgrade.SetActive(false);
    }

    public void ShowHealingWindow()
    {
        _heal.SetActive(true);
        _heal.GetComponent<CharacterSelection>().ShowSelection();
        _currentInterface.SetActive(false);
    }


    public void Upgrade()
    {
        string code;

        if (_currentInterface.name == "Armory") code = "A";
        else if (_currentInterface.name == "Gym") code = "G";
        else if (_currentInterface.name == "Healer'sHut") code = "HH";
        else if (_currentInterface.name == "Scout'sHut") code = "SH";
        else code = "CS";

        if (CurrencyManager.cheese >= 5)
        {
            AudioManager.Instance.Play("Building");

            BuildingManager.Instance.UpgradeBuilding(code);

            if (code == "A") _currentInterface.GetComponentInChildren<Armory>().UpdateText();
            if (code == "G") _currentInterface.GetComponentInChildren<Gym>().UpdateText();
            if (code == "HH") _currentInterface.GetComponentInChildren<HealersHut>().UpdateText();
            if (code == "SH") _currentInterface.GetComponentInChildren<ScoutsHut>().UpdateText();
            if (code == "CS") _currentInterface.GetComponentInChildren<CheeseStorage>().UpdateText();

            CurrencyManager.cheese -= 5;
            CurrencyManager.UpdateCheese();
            MenuManager.Instance.UpdateCurrencyDisplay();
        }
    }

    public void Exit()
    {
        _currentInterface.SetActive(false);
        PreventMultipleUi.Instance.isUIWindowOpen = false;
    }
}
