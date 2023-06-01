using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSlotManager : MonoBehaviour
{
    public static BuildSlotManager Instance;

    [SerializeField]
    private GameObject _armory, _gym, _healersHut, _scoutsHut, _cheeseStorage;

    [SerializeField]
    private GameObject _armoryBuildSlot, _gymBuildSlot, _healersHutBuildSlot, _scoutsHutBuildSlot, _cheeseStorageBuildSlot;

    [SerializeField]
    private GameObject _toBuildA, _toBuildG, _toBuildHH, _toBuildSH, _toBuildCS;

    void Awake()
    {
        Instance = this;
        CurrencyManager.cheese = 50;
        CurrencyManager.UpdateCheese();
        MenuManager.Instance.UpdateCurrencyDisplay();
    }

    public void AskAboutArmory()
    {
        if (!PreventMultipleUi.Instance.isUIWindowOpen)
        {
            _toBuildA.SetActive(true);
            _armoryBuildSlot.SetActive(false);
            PreventMultipleUi.Instance.isUIWindowOpen = true;
        }
    }

    public void AskAboutGym()
    {
        if (!PreventMultipleUi.Instance.isUIWindowOpen)
        {
            _toBuildG.SetActive(true);
            _gymBuildSlot.SetActive(false);
            PreventMultipleUi.Instance.isUIWindowOpen = true;
        }
    }

    public void AskAboutHealersHut()
    {
        if (!PreventMultipleUi.Instance.isUIWindowOpen)
        {
            _toBuildHH.SetActive(true);
            _healersHutBuildSlot.SetActive(false);
            PreventMultipleUi.Instance.isUIWindowOpen = true;
        }
    }

    public void AskAboutScoutsHut()
    {
        if (!PreventMultipleUi.Instance.isUIWindowOpen)
        {
            _toBuildSH.SetActive(true);
            _scoutsHutBuildSlot.SetActive(false);
            PreventMultipleUi.Instance.isUIWindowOpen = true;
        }
    }

    public void AskAboutCheeseStorage()
    {
        if (!PreventMultipleUi.Instance.isUIWindowOpen)
        {
            _toBuildCS.SetActive(true);
            _cheeseStorageBuildSlot.SetActive(false);
            PreventMultipleUi.Instance.isUIWindowOpen = true;
        }
    }

    public void Build(GameObject buildingSlot)
    {
        if (buildingSlot == _armoryBuildSlot) BuildArmory();
        if (buildingSlot == _gymBuildSlot) BuildGym();
        if (buildingSlot == _healersHutBuildSlot) BuildHealersHut();
        if (buildingSlot == _scoutsHutBuildSlot) BuildScoutsHut();
        if (buildingSlot == _cheeseStorageBuildSlot) BuildCheeseStorage();
    }

    public void BuildArmory()
    {
        _armory.SetActive(true);
        _armoryBuildSlot.SetActive(false);

        BuildingManager.Instance.isABuilt = true;
    }

    public void BuildGym()
    {
        _gym.SetActive(true);
        _gymBuildSlot.SetActive(false);

        BuildingManager.Instance.isGBuilt = true;
    }

    public void BuildHealersHut()
    {
        _healersHut.SetActive(true);
        _healersHutBuildSlot.SetActive(false);

        BuildingManager.Instance.isHHBuilt = true;
    }

    public void BuildScoutsHut()
    {
        _scoutsHut.SetActive(true);
        _scoutsHutBuildSlot.SetActive(false);

        BuildingManager.Instance.isSHBuilt = true;
    }

    public void BuildCheeseStorage()
    {
        _cheeseStorage.SetActive(true);
        _cheeseStorageBuildSlot.SetActive(false);

        BuildingManager.Instance.isCSBuilt = true;
    }
}
