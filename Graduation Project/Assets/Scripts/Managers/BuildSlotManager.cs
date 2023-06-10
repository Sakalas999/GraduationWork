using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    [SerializeField]
    private GameObject _raid, _raidText;

    [SerializeField]
    private GameObject _smoke;

    void Awake()
    {
        Instance = this;
        
        if (PlayerPrefs.GetInt("Raid") == 1)
        {
            int randomBuilding = Random.Range(1, 5);
            int randomLevel = Random.Range(1, 5);

            PlayerPrefs.SetInt("Raid", 0);
            PlayerPrefs.Save();

            _raid.SetActive(true);
            //PreventMultipleUi.Instance.isUIWindowOpen = true;

            if (randomBuilding == 1)
            {
                if (BuildingManager.Instance.isABuilt)
                {
                    if (BuildingManager.Instance.ALevel >= randomLevel)
                    {
                        for (int i = 0; i < randomLevel; i++)
                        {
                            BuildingManager.Instance.DecreseBuilding("A");
                        }
                        if (CurrencyManager.cheese > 0)
                        {
                            CurrencyManager.cheese -= Mathf.RoundToInt(CurrencyManager.cheese * 0.25f);
                            _raidText.GetComponent<TextMeshProUGUI>().text = "Your base has been raided, you have lost " + Mathf.RoundToInt(CurrencyManager.cheese * 0.25f) +
                                " amount of cheese and your Armory's level has been decreased by " + randomLevel;
                        }
                        else
                        {
                            _raidText.GetComponent<TextMeshProUGUI>().text = "Your base has been raided. Your Armory's level has been decreased by " + randomLevel;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < BuildingManager.Instance.ALevel; i++)
                        {
                            BuildingManager.Instance.DecreseBuilding("A");
                        }

                        if (CurrencyManager.cheese > 0)
                        {
                            CurrencyManager.cheese -= Mathf.RoundToInt(CurrencyManager.cheese * 0.25f);
                            _raidText.GetComponent<TextMeshProUGUI>().text = "Your base has been raided, you have lost " + Mathf.RoundToInt(CurrencyManager.cheese * 0.25f) +
                                " amount of cheese and your Armory has been destroyed";
                        }
                        else
                        {
                            _raidText.GetComponent<TextMeshProUGUI>().text = "Your base has been raided. Your Armory has been destroyed";
                        }
                    }
                }
                else
                {
                    if (CurrencyManager.cheese > 0)
                    {
                        CurrencyManager.cheese -= Mathf.RoundToInt(CurrencyManager.cheese * 0.25f);
                        _raidText.GetComponent<TextMeshProUGUI>().text = "Your base has been raided, you have lost " + Mathf.RoundToInt(CurrencyManager.cheese * 0.25f) 
                            + " amount of cheese";
                    }
                    else
                    {
                        _raidText.GetComponent<TextMeshProUGUI>().text = "Your base has been raided. However nothing was stolen nor destroyed";
                    }
                }
            } 
            else if (randomBuilding == 2)
            {
                if (BuildingManager.Instance.isGBuilt)
                {
                    if (BuildingManager.Instance.GLevel >= randomLevel)
                    {
                        for (int i = 0; i < randomLevel; i++)
                        {
                            BuildingManager.Instance.DecreseBuilding("G");      
                        }

                        if (CurrencyManager.cheese > 0)
                        {
                            CurrencyManager.cheese -= Mathf.RoundToInt(CurrencyManager.cheese * 0.25f);
                            _raidText.GetComponent<TextMeshProUGUI>().text = "Your base has been raided, you have lost " + Mathf.RoundToInt(CurrencyManager.cheese * 0.25f) +
                                " amount of cheese and your Gym's level has been decreased by " + randomLevel;
                        }
                        else
                        {
                            _raidText.GetComponent<TextMeshProUGUI>().text = "Your base has been raided. Your Gym's level has been decreased by " + randomLevel;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < BuildingManager.Instance.GLevel; i++)
                        {
                            BuildingManager.Instance.DecreseBuilding("G");
                        }

                        if (CurrencyManager.cheese > 0)
                        {
                            CurrencyManager.cheese -= Mathf.RoundToInt(CurrencyManager.cheese * 0.25f);
                            _raidText.GetComponent<TextMeshProUGUI>().text = "Your base has been raided, you have lost " + Mathf.RoundToInt(CurrencyManager.cheese * 0.25f) +
                                " amount of cheese and your Gym has been destroyed";
                        }
                        else
                        {
                            _raidText.GetComponent<TextMeshProUGUI>().text = "Your base has been raided. Your Gym has been destroyed";
                        }
                    }
                }
                else
                {
                    if (CurrencyManager.cheese > 0)
                    {
                        CurrencyManager.cheese -= Mathf.RoundToInt(CurrencyManager.cheese * 0.25f);
                        _raidText.GetComponent<TextMeshProUGUI>().text = "Your base has been raided, you have lost " + Mathf.RoundToInt(CurrencyManager.cheese * 0.25f) 
                            + " amount of cheese";
                    }
                    else
                    {
                        _raidText.GetComponent<TextMeshProUGUI>().text = "Your base has been raided. However nothing was stolen nor destroyed";
                    }
                }
            }
            else if (randomBuilding == 3)
            {
                if (BuildingManager.Instance.isHHBuilt)
                {
                    PlayerPrefs.SetInt("isHHBuilt", 0);
                    PlayerPrefs.Save();

                    if (CurrencyManager.cheese > 0)
                    {
                        CurrencyManager.cheese -= Mathf.RoundToInt(CurrencyManager.cheese * 0.25f);
                        _raidText.GetComponent<TextMeshProUGUI>().text = "Your base has been raided, you have lost " + Mathf.RoundToInt(CurrencyManager.cheese * 0.25f) +
                            " amount of cheese and your Healer's Hut has been destroyed";
                    }
                    else
                    {
                        _raidText.GetComponent<TextMeshProUGUI>().text = "Your base has been raided. Your Healer's Hut has been destroyed";
                    }
                }
                else
                {

                    if (CurrencyManager.cheese > 0)
                    {
                        CurrencyManager.cheese -= Mathf.RoundToInt(CurrencyManager.cheese * 0.25f);
                        _raidText.GetComponent<TextMeshProUGUI>().text = "Your base has been raided, you have lost " + Mathf.RoundToInt(CurrencyManager.cheese * 0.25f) 
                            + " amount of cheese";
                    }
                    else
                    {
                        _raidText.GetComponent<TextMeshProUGUI>().text = "Your base has been raided. However nothing was stolen nor destroyed";
                    }
                }
            }
            else if (randomBuilding == 4)
            {
                if (BuildingManager.Instance.isSHBuilt)
                {
                    if (BuildingManager.Instance.SHLevel >= randomLevel)
                    {
                        for (int i = 0; i < randomLevel; i++)
                        {
                            BuildingManager.Instance.DecreseBuilding("SH");
                        }

                        if (CurrencyManager.cheese > 0)
                        {
                            CurrencyManager.cheese -= Mathf.RoundToInt(CurrencyManager.cheese * 0.25f);
                            _raidText.GetComponent<TextMeshProUGUI>().text = "Your base has been raided, you have lost " + Mathf.RoundToInt(CurrencyManager.cheese * 0.25f) +
                                " amount of cheese and your Scout's Hut level has been decreased by " + randomLevel;
                        }
                        else
                        {
                            _raidText.GetComponent<TextMeshProUGUI>().text = "Your base has been raided. Your Scout's Hut level has been decreased by " + randomLevel;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < BuildingManager.Instance.SHLevel; i++)
                        {
                            BuildingManager.Instance.DecreseBuilding("SH");
                        }

                        if (CurrencyManager.cheese > 0)
                        {
                            CurrencyManager.cheese -= Mathf.RoundToInt(CurrencyManager.cheese * 0.25f);
                            _raidText.GetComponent<TextMeshProUGUI>().text = "Your base has been raided, you have lost " + Mathf.RoundToInt(CurrencyManager.cheese * 0.25f) +
                                " amount of cheese and your Scout's Hut has been destroyed";
                        }
                        else
                        {
                            _raidText.GetComponent<TextMeshProUGUI>().text = "Your base has been raided. Your Scout's Hut has been destroyed";
                        }
                    }
                }
                else
                {
                    if (CurrencyManager.cheese > 0)
                    {
                        CurrencyManager.cheese -= Mathf.RoundToInt(CurrencyManager.cheese * 0.25f);
                        _raidText.GetComponent<TextMeshProUGUI>().text = "Your base has been raided, you have lost " + Mathf.RoundToInt(CurrencyManager.cheese * 0.25f)
                             + " amount of cheese";
                    }
                    else
                    {
                        _raidText.GetComponent<TextMeshProUGUI>().text = "Your base has been raided. However nothing was stolen nor destroyed";
                    }
                }
            }
            else
            {
                if (BuildingManager.Instance.isCSBuilt)
                {
                    if (BuildingManager.Instance.CSLevel >= randomLevel)
                    {
                        for (int i = 0; i < randomLevel; i++)
                        {
                            BuildingManager.Instance.DecreseBuilding("CS");
                        }

                        if (CurrencyManager.cheese > 0)
                        {
                            CurrencyManager.cheese -= Mathf.RoundToInt(CurrencyManager.cheese * 0.25f);
                            _raidText.GetComponent<TextMeshProUGUI>().text = "Your base has been raided, you have lost " + Mathf.RoundToInt(CurrencyManager.cheese * 0.25f) +
                                " amount of cheese and your Cheese Storage's level has been decreased by " + randomLevel;
                        }
                        else
                        {
                            _raidText.GetComponent<TextMeshProUGUI>().text = "Your base has been raided. Your Cheese Hut's level has been decreased by " + randomLevel;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < BuildingManager.Instance.CSLevel; i++)
                        {
                            BuildingManager.Instance.DecreseBuilding("CS");
                        }


                        if (CurrencyManager.cheese > 0)
                        {
                            CurrencyManager.cheese -= Mathf.RoundToInt(CurrencyManager.cheese * 0.25f);
                            _raidText.GetComponent<TextMeshProUGUI>().text = "Your base has been raided, you have lost " + Mathf.RoundToInt(CurrencyManager.cheese * 0.25f) +
                                " amount of cheese and your Cheese Hut's has been destroyed";
                        }
                        else
                        {
                            _raidText.GetComponent<TextMeshProUGUI>().text = "Your base has been raided. Your Cheese Hut's has been destroyed";
                        }
                    }
                }
                else
                {
                    if (CurrencyManager.cheese > 0)
                    {
                        CurrencyManager.cheese -= Mathf.RoundToInt(CurrencyManager.cheese * 0.25f);
                        _raidText.GetComponent<TextMeshProUGUI>().text = "Your base has been raided, you have lost " + Mathf.RoundToInt(CurrencyManager.cheese * 0.25f)
                             + " amount of cheese";
                    }
                    else
                    {
                        _raidText.GetComponent<TextMeshProUGUI>().text = "Your base has been raided. However nothing was stolen nor destroyed";
                    }
                }
            }     
        }

        if (BuildingManager.Instance.isABuilt)
        {
            _armoryBuildSlot.SetActive(false);
            _armory.SetActive(true);
        }

        if (BuildingManager.Instance.isGBuilt)
        {
            _gymBuildSlot.SetActive(false);
            _gym.SetActive(true);
        }

        if (BuildingManager.Instance.isHHBuilt)
        {
            _healersHutBuildSlot.SetActive(false);
            _healersHut.SetActive(true);
        }

        if (BuildingManager.Instance.isSHBuilt)
        {
            _scoutsHutBuildSlot.SetActive(false);
            _scoutsHut.SetActive(true);
        }

        if (BuildingManager.Instance.isCSBuilt)
        {
            _cheeseStorageBuildSlot.SetActive(false);
            _cheeseStorage.SetActive(true);
        }
    }

    private void Start()
    {
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

        _smoke.transform.position = _armory.transform.position;
        _smoke.GetComponent<ParticleSystem>().Play();

        BuildingManager.Instance.isABuilt = true;
        PlayerPrefs.SetInt("isABuilt", 1);
        PlayerPrefs.Save();
        BuildingManager.Instance.UpgradeBuilding("A");
    }

    public void BuildGym()
    {
        _gym.SetActive(true);
        _gymBuildSlot.SetActive(false);

        _smoke.transform.position = _gym.transform.position;
        _smoke.GetComponent<ParticleSystem>().Play();

        BuildingManager.Instance.isGBuilt = true;
        PlayerPrefs.SetInt("isGBuilt", 1);
        PlayerPrefs.Save();
        BuildingManager.Instance.UpgradeBuilding("G");
    }

    public void BuildHealersHut()
    {
        _healersHut.SetActive(true);
        _healersHutBuildSlot.SetActive(false);

        _smoke.transform.position = _healersHut.transform.position;
        _smoke.GetComponent<ParticleSystem>().Play();

        BuildingManager.Instance.isHHBuilt = true;
        PlayerPrefs.SetInt("isHHBuilt", 1);
        PlayerPrefs.Save();
    }

    public void BuildScoutsHut()
    {
        _scoutsHut.SetActive(true);
        _scoutsHutBuildSlot.SetActive(false);

        _smoke.transform.position = _scoutsHut.transform.position;
        _smoke.GetComponent<ParticleSystem>().Play();

        BuildingManager.Instance.isSHBuilt = true;
        PlayerPrefs.SetInt("isSHBuilt", 1);
        PlayerPrefs.Save();
        BuildingManager.Instance.UpgradeBuilding("SH");
    }

    public void BuildCheeseStorage()
    {
        _cheeseStorage.SetActive(true);
        _cheeseStorageBuildSlot.SetActive(false);

        _smoke.transform.position = _cheeseStorage.transform.position;
        _smoke.GetComponent<ParticleSystem>().Play();

        BuildingManager.Instance.isCSBuilt = true;
        PlayerPrefs.SetInt("isCSBuilt", 1);
        PlayerPrefs.Save();
        BuildingManager.Instance.UpgradeBuilding("CS");
    }

    public void CloseRaidEvent()
    {
        _raid.SetActive(false);
        PreventMultipleUi.Instance.isUIWindowOpen = false;
    }
}
