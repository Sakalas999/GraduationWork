using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public const string Cheese = "Chees";
    public static int cheese = 0;


    private void Awake()
    {
        cheese = PlayerPrefs.GetInt("cheese");
    }

    void Update()
    {
        
    }

    //Updates the currency amount
    public static void UpdateCheese()
    {
        PlayerPrefs.SetInt("cheese", cheese);
        cheese = PlayerPrefs.GetInt("cheese");
        PlayerPrefs.Save();
    }
}
