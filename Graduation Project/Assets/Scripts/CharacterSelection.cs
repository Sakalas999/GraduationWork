using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
   [SerializeField] private GameObject _firstRatHero, _secondRatHero, _thirdRatHero, _firstDogHero, _secondDogHero;

    private bool _selectedFirstRat, _selectedSecondRat, _selectedThirdRat, _selectedFirstDog, _selectedSecondDog;
    private Color _ogFirstRat, _ogSecondRat, _ogThirdRat, _ogFirstDog, _ogSecondDog;


    public void Start()
    {
        _ogFirstRat = _firstRatHero.GetComponent<Image>().color;
        _ogFirstDog = _firstDogHero.GetComponent<Image>().color;
        _ogSecondRat = _secondRatHero.GetComponent<Image>().color;
        _ogSecondDog = _secondDogHero.GetComponent<Image>().color;
        _ogThirdRat = _thirdRatHero.GetComponent<Image>().color;
    }

    public void ShowSelection()
    {
        if (InfoOnOwnedCharacters.Instance.isOwnedH1)
        {
            _firstRatHero.SetActive(true);
        }
        else
        {
            _firstRatHero.SetActive(false);
        }

        if (InfoOnOwnedCharacters.Instance.isOwnedH2)
        {
            _firstDogHero.SetActive(true);
        }
        else
        {
            _firstDogHero.SetActive(false);
        }

        if (InfoOnOwnedCharacters.Instance.isOwnedH3)
        {
            _secondRatHero.SetActive(true);
        }
        else
        {
            _secondRatHero.SetActive(false);
        }

        if (InfoOnOwnedCharacters.Instance.isOwnedH4)
        {
            _secondDogHero.SetActive(true);
        }
        else
        {
            _secondDogHero.SetActive(false);
        }

        if (InfoOnOwnedCharacters.Instance.isOwnedH5)
        {
            _thirdRatHero.SetActive(true);
        }
        else
        {
            _thirdRatHero.SetActive(false);
        }
    }

    public void SelectedFirst()
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

    public void SelectedSecond()
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

    public void SelectedThird()
    {
        if (_selectedSecondRat)
        {
            _selectedSecondRat = false;
            _secondRatHero.GetComponent<Image>().color = _ogSecondRat;
        }
        else
        {
            _selectedSecondRat = true;
            _secondRatHero.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.5f);
        }
    }  

    public void SelectedFourth()
    {
        if (_selectedSecondDog)
        {
            _selectedSecondDog = false;
            _secondDogHero.GetComponent<Image>().color = _ogSecondDog;
        }
        else
        {
            _selectedSecondDog = true;
            _secondDogHero.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.5f);
        }
    }

    public void SelectedFifth()
    {
        if (_selectedThirdRat)
        {
            _selectedThirdRat = false;
            _thirdRatHero.GetComponent<Image>().color = _ogThirdRat;
        }
        else
        {
            _selectedThirdRat = true;
            _thirdRatHero.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.5f);
        }
    }

    public void Proceed()
    {
        SceneManager.LoadScene(1);
    }
}
