using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static int cheese = 0;
    public static int count = 0;


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

    public static void Count(int amountOfType1, int amountOfType2, int amountOfType3)
    {
        int count1 = amountOfType1 * 1 * PlayerPrefs.GetInt("CheeseMultiplier");
        int count2 = amountOfType2 * 2 * PlayerPrefs.GetInt("CheeseMultiplier");
        int count3 = amountOfType3 * 3 * PlayerPrefs.GetInt("CheeseMultiplier");

        count = count1 + count2 + count3;
    }
}
