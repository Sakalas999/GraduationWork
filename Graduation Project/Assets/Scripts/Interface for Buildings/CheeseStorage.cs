using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseStorage : MonoBehaviour
{
    private string _text;

    public void UpdateText()
    {
        _text = "The Cheese storage is currently " + BuildingManager.Instance.CSLevel + " level. Current level provides " +
               BuildingManager.Instance.CSLevel * 1 + " pieces of cheese every time coming back to base. For 5 cheese you can upgrade this building to increase it's effect.";
        this.GetComponentInParent<BuildingsInterfaces>().UpdateMainText(_text);
    }
}
