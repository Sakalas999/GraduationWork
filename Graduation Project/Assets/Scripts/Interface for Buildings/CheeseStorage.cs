using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseStorage : MonoBehaviour
{
    private string _text;

    public void UpdateText()
    {
        if (BuildingManager.Instance.CSLevel < 5)
        {
            _text = "The Cheese storage is currently " + BuildingManager.Instance.CSLevel + " level. Current level provides " +
                   (BuildingManager.Instance.CSLevel + 1) + " multiplier to recieved cheese trough any means. For 5 cheese you can upgrade this building to increase it's effect.";
            this.GetComponentInParent<BuildingsInterfaces>().UpdateMainText(_text);
        }
        else
        {
            GetComponentInParent<BuildingsInterfaces>().HideUpgrade();
            _text = "The Cheese storage is currently at the maximum level at the level of " + BuildingManager.Instance.CSLevel + ". Current level provides " +
                  (BuildingManager.Instance.CSLevel + 1) + " multiplier to recieved cheese trough any means.";
            this.GetComponentInParent<BuildingsInterfaces>().UpdateMainText(_text);
        }

    }
}
