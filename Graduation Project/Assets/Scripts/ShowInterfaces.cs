using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInterfaces : MonoBehaviour
{
    [SerializeField]
    private GameObject _armoryInterface, _gymInterface, _healersHutInterface, _scoutsHutInterface, _cheeseStorageInterface;

    public void ShowArmoryInterface()
    {
        if (!PreventMultipleUi.Instance.isUIWindowOpen)
        {
            _armoryInterface.SetActive(true);
            _armoryInterface.GetComponentInChildren<Armory>().UpdateText();
            PreventMultipleUi.Instance.isUIWindowOpen = true;
        }
    }

    public void ShowGymInterface()
    {
        if (!PreventMultipleUi.Instance.isUIWindowOpen)
        {
            _gymInterface.SetActive(true);
            _gymInterface.GetComponentInChildren<Gym>().UpdateText();
            PreventMultipleUi.Instance.isUIWindowOpen = true;
        }
    }

    public void ShowHealersHutInterface()
    {
        if (!PreventMultipleUi.Instance.isUIWindowOpen)
        {
            _healersHutInterface.SetActive(true);
            _healersHutInterface.GetComponentInChildren<HealersHut>().UpdateText();
            PreventMultipleUi.Instance.isUIWindowOpen = true;
        }
    }

    public void ShowScoutsHutInterface()
    {
        if (!PreventMultipleUi.Instance.isUIWindowOpen)
        {
            _scoutsHutInterface.SetActive(true);
            _scoutsHutInterface.GetComponentInChildren<ScoutsHut>().UpdateText();
            PreventMultipleUi.Instance.isUIWindowOpen = true;
        }
    }

    public void ShowCheeseStorageInterface()
    {
        if (!PreventMultipleUi.Instance.isUIWindowOpen)
        {
            _cheeseStorageInterface.SetActive(true);
            _cheeseStorageInterface.GetComponentInChildren<CheeseStorage>().UpdateText();
            PreventMultipleUi.Instance.isUIWindowOpen = true;
        }
    }
}
