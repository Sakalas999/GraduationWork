using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] private GameObject _firstRatHero, _secondRatHero, _thirdRatHero, _firstDogHero, _secondDogHero, _healersHutInterface;
    [SerializeField] private GameObject[] woundedAttribute = new GameObject[5];
    [SerializeField] private GameObject _proceedButton, _closeButton;

    private bool _selectedFirstRat, _selectedSecondRat, _selectedThirdRat, _selectedFirstDog, _selectedSecondDog;
    private Color _ogFirstRat, _ogSecondRat, _ogThirdRat, _ogFirstDog, _ogSecondDog;
    private GameObject _currentGameObject;


    public void Start()
    {
        _ogFirstRat = _firstRatHero.GetComponent<Image>().color;
        _ogFirstDog = _firstDogHero.GetComponent<Image>().color;
        _ogSecondRat = _secondRatHero.GetComponent<Image>().color;
        _ogSecondDog = _secondDogHero.GetComponent<Image>().color;
        _ogThirdRat = _thirdRatHero.GetComponent<Image>().color;

        _currentGameObject = this.gameObject;
    }

    public void ShowSelection()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (Map.Instance.characterWindowOpen)
            {
                _proceedButton.SetActive(false);
                _closeButton.SetActive(true);
            }
            else
            {
                _proceedButton.SetActive(true);
                _closeButton.SetActive(false);
            }

            if (InfoOnOwnedCharacters.Instance.isOwnedH1)
            {
                _firstRatHero.SetActive(true);

                if (InfoOnOwnedCharacters.Instance.isWoundedH1)
                {
                    woundedAttribute[0].SetActive(true);
                }
                else
                {
                    woundedAttribute[0].SetActive(false);
                }
            }
            else
            {
                _firstRatHero.SetActive(false);
            }

            if (InfoOnOwnedCharacters.Instance.isOwnedH2)
            {
                _firstDogHero.SetActive(true);

                if (InfoOnOwnedCharacters.Instance.isWoundedH2)
                {
                    woundedAttribute[1].SetActive(true);
                }
                else
                {
                    woundedAttribute[1].SetActive(false);
                }
            }
            else
            {
                _firstDogHero.SetActive(false);
            }

            if (InfoOnOwnedCharacters.Instance.isOwnedH3)
            {
                _secondRatHero.SetActive(true);

                if (InfoOnOwnedCharacters.Instance.isWoundedH3)
                {
                    woundedAttribute[2].SetActive(true);
                }
                else
                {
                    woundedAttribute[2].SetActive(false);
                }
            }
            else
            {
                _secondRatHero.SetActive(false);
            }

            if (InfoOnOwnedCharacters.Instance.isOwnedH4)
            {
                _secondDogHero.SetActive(true);

                if (InfoOnOwnedCharacters.Instance.isWoundedH4)
                {
                    woundedAttribute[3].SetActive(true);
                }
                else
                {
                    woundedAttribute[3].SetActive(false);
                }
            }
            else
            {
                _secondDogHero.SetActive(false);
            }

            if (InfoOnOwnedCharacters.Instance.isOwnedH5)
            {
                _thirdRatHero.SetActive(true);

                if (InfoOnOwnedCharacters.Instance.isWoundedH5)
                {
                    woundedAttribute[4].SetActive(true);
                }
                else
                {
                    woundedAttribute[4].SetActive(false);
                }
            }
            else
            {
                _thirdRatHero.SetActive(false);
            }
        }
        else
        {
            if (InfoOnOwnedCharacters.Instance.isOwnedH1 && InfoOnOwnedCharacters.Instance.isWoundedH1)
            {
                _firstRatHero.SetActive(true);
                woundedAttribute[0].SetActive(true);
            }
            else
            {
                _firstRatHero.SetActive(false);
            }

            if (InfoOnOwnedCharacters.Instance.isOwnedH2 && InfoOnOwnedCharacters.Instance.isWoundedH2)
            {
                _firstDogHero.SetActive(true);
                woundedAttribute[1].SetActive(true);
            }
            else
            {
                _firstDogHero.SetActive(false);
            }

            if (InfoOnOwnedCharacters.Instance.isOwnedH3 && InfoOnOwnedCharacters.Instance.isWoundedH3)
            {
                _secondRatHero.SetActive(true);
                woundedAttribute[2].SetActive(true);
            }
            else
            {
                _secondRatHero.SetActive(false);
            }

            if (InfoOnOwnedCharacters.Instance.isOwnedH4 && InfoOnOwnedCharacters.Instance.isWoundedH4)
            {
                _secondDogHero.SetActive(true);
                woundedAttribute[3].SetActive(true);
            }
            else
            {
                _secondDogHero.SetActive(false);
            }

            if (InfoOnOwnedCharacters.Instance.isOwnedH5 && InfoOnOwnedCharacters.Instance.isWoundedH5)
            {
                _thirdRatHero.SetActive(true);
                woundedAttribute[4].SetActive(true);
            }
            else
            {
                _thirdRatHero.SetActive(false);
            }
        }
    }

    public void SelectedFirst()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 && !Map.Instance.characterWindowOpen)
        {
            if (_selectedFirstRat)
            {
                _selectedFirstRat = false;
                _firstRatHero.GetComponent<Image>().color = _ogFirstRat;
                InfoOnOwnedCharacters.Instance.DeselectHero(1);
            }
            else
            {
                _selectedFirstRat = true;
                _firstRatHero.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.5f);
                InfoOnOwnedCharacters.Instance.SelectedHeros(1);
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (_selectedFirstRat)
            {
                _selectedFirstRat = false;
                _firstRatHero.GetComponent<Image>().color = _ogFirstRat;
                InfoOnOwnedCharacters.Instance.DeselectHero(1);
            }
            else
            {
                _selectedFirstRat = true;
                _firstRatHero.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.5f);
                InfoOnOwnedCharacters.Instance.SelectedHeros(1);
            }
        }
    }

    public void SelectedSecond()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 && !Map.Instance.characterWindowOpen)
        {
            if (_selectedFirstDog)
            {
                _selectedFirstDog = false;
                _firstDogHero.GetComponent<Image>().color = _ogFirstDog;
                InfoOnOwnedCharacters.Instance.DeselectHero(2);
            }
            else
            {
                _selectedFirstDog = true;
                _firstDogHero.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.5f);
                InfoOnOwnedCharacters.Instance.SelectedHeros(2);
            }
        }
        
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (_selectedFirstDog)
            {
                _selectedFirstDog = false;
                _firstDogHero.GetComponent<Image>().color = _ogFirstDog;
                InfoOnOwnedCharacters.Instance.DeselectHero(2);
            }
            else
            {
                _selectedFirstDog = true;
                _firstDogHero.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.5f);
                InfoOnOwnedCharacters.Instance.SelectedHeros(2);
            }
        }
    }

    public void SelectedThird()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 && !Map.Instance.characterWindowOpen)
        {
            if (_selectedSecondRat)
            {
                _selectedSecondRat = false;
                _secondRatHero.GetComponent<Image>().color = _ogSecondRat;
                InfoOnOwnedCharacters.Instance.DeselectHero(3);
            }
            else
            {
                _selectedSecondRat = true;
                _secondRatHero.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.5f);
                InfoOnOwnedCharacters.Instance.SelectedHeros(3);
            }
        }
        
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (_selectedSecondRat)
            {
                _selectedSecondRat = false;
                _secondRatHero.GetComponent<Image>().color = _ogSecondRat;
                InfoOnOwnedCharacters.Instance.DeselectHero(3);
            }
            else
            {
                _selectedSecondRat = true;
                _secondRatHero.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.5f);
                InfoOnOwnedCharacters.Instance.SelectedHeros(3);
            }
        }
    }  

    public void SelectedFourth()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 && !Map.Instance.characterWindowOpen)
        {
            if (_selectedSecondDog)
            {
                _selectedSecondDog = false;
                _secondDogHero.GetComponent<Image>().color = _ogSecondDog;
                InfoOnOwnedCharacters.Instance.DeselectHero(4);
            }
            else
            {
                _selectedSecondDog = true;
                _secondDogHero.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.5f);
                InfoOnOwnedCharacters.Instance.SelectedHeros(4);
            }
        }
        
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (_selectedSecondDog)
            {
                _selectedSecondDog = false;
                _secondDogHero.GetComponent<Image>().color = _ogSecondDog;
                InfoOnOwnedCharacters.Instance.DeselectHero(4);
            }
            else
            {
                _selectedSecondDog = true;
                _secondDogHero.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.5f);
                InfoOnOwnedCharacters.Instance.SelectedHeros(4);
            }
        }
    }

    public void SelectedFifth()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 && !Map.Instance.characterWindowOpen)
        {
            if (_selectedThirdRat)
            {
                _selectedThirdRat = false;
                _thirdRatHero.GetComponent<Image>().color = _ogThirdRat;
                InfoOnOwnedCharacters.Instance.DeselectHero(5);
            }
            else
            {
                _selectedThirdRat = true;
                _thirdRatHero.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.5f);
                InfoOnOwnedCharacters.Instance.SelectedHeros(5);
            }
        }
        
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {

            if (_selectedThirdRat)
            {
                _selectedThirdRat = false;
                _thirdRatHero.GetComponent<Image>().color = _ogThirdRat;
                InfoOnOwnedCharacters.Instance.DeselectHero(5);
            }
            else
            {
                _selectedThirdRat = true;
                _thirdRatHero.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.5f);
                InfoOnOwnedCharacters.Instance.SelectedHeros(5);
            }
        }
    }

    public void Proceed()
    {
        int count = 0;
        if (_selectedFirstRat) count++;
        if (_selectedFirstDog) count++;
        if (_selectedSecondRat) count++;
        if (_selectedSecondDog) count++;
        if (_selectedThirdRat) count++;

        if (count > 0 && count < 4)
            SceneManager.LoadScene(2);
        else
        {
            count = 0;

            _selectedFirstRat = false;
            _firstRatHero.GetComponent<Image>().color = _ogFirstRat;
            InfoOnOwnedCharacters.Instance.DeselectHero(1);

            _selectedFirstDog = false;
            _firstDogHero.GetComponent<Image>().color = _ogFirstDog;
            InfoOnOwnedCharacters.Instance.DeselectHero(2);

            _selectedSecondRat = false;
            _secondRatHero.GetComponent<Image>().color = _ogSecondRat;
            InfoOnOwnedCharacters.Instance.DeselectHero(3);

            _selectedSecondDog = false;
            _secondDogHero.GetComponent<Image>().color = _ogSecondDog;
            InfoOnOwnedCharacters.Instance.DeselectHero(4);

            _selectedThirdRat = false;
            _thirdRatHero.GetComponent<Image>().color = _ogThirdRat;
            InfoOnOwnedCharacters.Instance.DeselectHero(5);
        }
    }

    public void Heal()
    {
        int count = 0;

        if (_selectedFirstRat || _selectedFirstDog || _selectedSecondRat || _selectedSecondDog || _selectedThirdRat)
        {
            if (_selectedFirstRat) count++;
            if (_selectedFirstDog) count++;
            if (_selectedSecondRat) count++;
            if (_selectedSecondDog) count++;
            if (_selectedThirdRat) count++;

            if (CurrencyManager.cheese >= count * 5)
            {
                if (_selectedFirstRat)
                {
                    InfoOnOwnedCharacters.Instance.UpdateWounded(1, false);
                    _selectedFirstRat = false;
                    _firstRatHero.GetComponent<Image>().color = _ogFirstRat;
                }
                if (_selectedFirstDog)
                {
                    InfoOnOwnedCharacters.Instance.UpdateWounded(2, false);
                    _selectedFirstDog = false;
                    _firstDogHero.GetComponent<Image>().color = _ogFirstDog;
                }
                if (_selectedSecondRat)
                {
                    InfoOnOwnedCharacters.Instance.UpdateWounded(3, false);
                    _selectedSecondRat = false;
                    _secondRatHero.GetComponent<Image>().color = _ogSecondRat;
                }
                if (_selectedSecondDog)
                {
                    InfoOnOwnedCharacters.Instance.UpdateWounded(4, false);
                    _selectedSecondDog = false;
                    _secondDogHero.GetComponent<Image>().color = _ogSecondDog;
                }
                if (_selectedThirdRat)
                {
                    InfoOnOwnedCharacters.Instance.UpdateWounded(5, false);
                    _selectedThirdRat = false;
                    _thirdRatHero.GetComponent<Image>().color = _ogThirdRat;
                }

                CurrencyManager.cheese -= count * 5;
                CurrencyManager.UpdateCheese();
                MenuManager.Instance.UpdateCurrencyDisplay();
                ShowSelection();
                count = 0;
            }
            else
            {
                count = 0;

                _selectedFirstRat = false;
                _firstRatHero.GetComponent<Image>().color = _ogFirstRat;
                InfoOnOwnedCharacters.Instance.DeselectHero(1);

                _selectedFirstDog = false;
                _firstDogHero.GetComponent<Image>().color = _ogFirstDog;
                InfoOnOwnedCharacters.Instance.DeselectHero(2);

                _selectedSecondRat = false;
                _secondRatHero.GetComponent<Image>().color = _ogSecondRat;
                InfoOnOwnedCharacters.Instance.DeselectHero(3);

                _selectedSecondDog = false;
                _secondDogHero.GetComponent<Image>().color = _ogSecondDog;
                InfoOnOwnedCharacters.Instance.DeselectHero(4);

                _selectedThirdRat = false;
                _thirdRatHero.GetComponent<Image>().color = _ogThirdRat;
                InfoOnOwnedCharacters.Instance.DeselectHero(5);
            }
        }           
    }

    public void GoBack()
    {
        _currentGameObject.SetActive(false);
        _healersHutInterface.SetActive(true);
    }

    public void Close()
    {
        _currentGameObject.SetActive(false);

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Map.Instance.eventOpen = false;
            Map.Instance.characterWindowOpen = false;
        }
        else
            PreventMultipleUi.Instance.isUIWindowOpen = false;
    }
}
