using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [SerializeField] private GameObject _selectedHeroObject, _tileUnitObject, _battleLostObject, _battleWonObject, _continueButton, _currencyDisplay, _resetWounded;
    [SerializeField] private TextMeshProUGUI _lossText, _rewardText;
    [SerializeField] private GameObject _mainMenu, _options;

    private Color _ogContinueButton;
    private string _textContinueButton;

    void Awake()
    {
        Instance = this;       
    }

    void Start()
    {
        if (_continueButton != null)
        {
            _ogContinueButton = _continueButton.GetComponent<Image>().color;
            _textContinueButton = _continueButton.GetComponentInChildren<TextMeshProUGUI>().text;

            if (PlayerPrefs.GetInt("NewGameInitialised") != 0)
            {
                _continueButton.GetComponent<Image>().color = _ogContinueButton;
                _continueButton.GetComponentInChildren<TextMeshProUGUI>().text = _textContinueButton;
            }
            else
            {
                _continueButton.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.5f);
                _continueButton.GetComponentInChildren<TextMeshProUGUI>().text = "";
            }
        }

        if (_currencyDisplay != null)
        {
            UpdateCurrencyDisplay();
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 4 || SceneManager.GetActiveScene().buildIndex != 5)
        {
            if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene(0);
        }
    }

    //Shows tile name
    public void ShowTileInfo(Tile tile)
    {

        if (tile == null || GameManager.Instance.GameState == GameState.BattleLost || GameManager.Instance.GameState == GameState.BattleWon)
        {
            _tileUnitObject.SetActive(false);
            return;
        }

        if (tile.occupiedUnit)
        {
            _tileUnitObject.GetComponentInChildren<TextMeshProUGUI>().text = tile.occupiedUnit.UnitName;
            _tileUnitObject.SetActive(true);
        }
    }

    //Shows selected hero's name
    public void ShowSelectedHero(BaseHero hero)
    {
        if (hero == null || GameManager.Instance.GameState == GameState.BattleLost || GameManager.Instance.GameState == GameState.BattleWon)
        {
            _selectedHeroObject.SetActive(false);
            return;
        }

        _selectedHeroObject.GetComponentInChildren<TextMeshProUGUI>().text = hero.UnitName;
        _selectedHeroObject.SetActive(true);
    }

    //Shows a battle lost scene
    public void ShowBattleLostScreen()
    {
        if (GameManager.Instance.GameState != GameState.BattleLost)
        {
            _battleLostObject.SetActive(false);
            return;
        }

        _battleLostObject.SetActive(true);
        _tileUnitObject.SetActive(false);
        _selectedHeroObject.SetActive(false);

        if (CurrencyManager.cheese >= CurrencyManager.count)
        {
            CurrencyManager.cheese -= CurrencyManager.count;
            CurrencyManager.UpdateCheese();

            UpdateCurrencyDisplay();
            _lossText.text = "You have lost " + CurrencyManager.count + " amount of cheese";
        }
        else if (CurrencyManager.cheese > 0)
        {
            CurrencyManager.cheese -= CurrencyManager.cheese;
            CurrencyManager.UpdateCheese();

            UpdateCurrencyDisplay();
            _lossText.text = "You have lost " + CurrencyManager.cheese + " amount of cheese";
        }
        else
        {
            _lossText.text = "You had nothing left to lose";
        }
    }

    //Shows a battle won scene
    public void ShowBattleWonScreen()
    {
        if (GameManager.Instance.GameState != GameState.BattleWon)
        {
            _battleWonObject.SetActive(false);
            return;
        }

        _battleWonObject.SetActive(true);
        _tileUnitObject.SetActive(false);
        _selectedHeroObject.SetActive(false);

        _rewardText.text = "You have received " + CurrencyManager.count + " amount of cheese";
    }

    //Displays Currency
    public void UpdateCurrencyDisplay()
    {
        TextMeshProUGUI text = _currencyDisplay.GetComponent<TextMeshProUGUI>();
        text.text = ""+CurrencyManager.cheese;
    }

    public void ResetWounded()
    {
        Hero1 hero1 = FindObjectOfType<Hero1>();
        hero1.UpdateIsWounded(false);
        Hero2 hero2 = FindObjectOfType<Hero2>();
        hero2.UpdateIsWounded(false);
    }

    public void LoadMapScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadBaseScene()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(0);
        Parameters.Instance.SetAllParametersToDefault();
    }

    public void NewGame()
    {
        Parameters.Instance.SetAllParametersToDefault();
        PlayerPrefs.SetInt("NewGameInitialised", 1);
        PlayerPrefs.Save();
        LoadMapScene();
    }

    public void Continue()
    {
        if (PlayerPrefs.GetInt("NewGameInitialised") != 0)
        {
            LoadMapScene();
        }
    }

    public void Options()
    {
        if (_options.active)
        {
            _options.SetActive(false);
            _mainMenu.SetActive(true);
        }
        else
        {
            if (Volume.Instance != null)
                Volume.Instance.LoadValues();

            _options.SetActive(true);
            _mainMenu.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}