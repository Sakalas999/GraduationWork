using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gym : MonoBehaviour
{
    private string _text;

    public void UpdateText()
    {
        if (BuildingManager.Instance.GLevel < 5)
        {
            _text = "The Gym is currently " + BuildingManager.Instance.GLevel + " level. Current level provides " +
                   BuildingManager.Instance.GLevel * 10 + " points to your heroes health. For 5 cheese you can upgrade this building to increase it's effect.";
            this.GetComponentInParent<BuildingsInterfaces>().UpdateMainText(_text);
        }
        else
        {
            GetComponentInParent<BuildingsInterfaces>().HideUpgrade();
            _text = "The Gym is currently at the maximum level at the level of " + BuildingManager.Instance.GLevel + ". Current level provides " +
                   BuildingManager.Instance.GLevel * 10 + " points to all of your heroes health.";
            this.GetComponentInParent<BuildingsInterfaces>().UpdateMainText(_text);
        }
    }
}
