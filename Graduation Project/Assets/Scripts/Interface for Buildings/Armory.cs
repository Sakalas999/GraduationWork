using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armory : MonoBehaviour
{
    private string _text;

    public void UpdateText()
    {
        _text = "The Armory is currently " + BuildingManager.Instance.ALevel + " level. Current level provides " +
               BuildingManager.Instance.ALevel * 5 + " points to your heroes damage dealt. For 5 cheese you can upgrade this building to increase it's effect.";
        this.GetComponentInParent<BuildingsInterfaces>().UpdateMainText(_text);
    }
}
