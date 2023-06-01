using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealersHut : MonoBehaviour
{
    private string _text;

    public void UpdateText()
    {
        _text = "The Healer's hut is currently " + BuildingManager.Instance.HHLevel + " level. Current level allows to heal " +
               BuildingManager.Instance.HHLevel + " number of your heroes. For 5 cheese you can upgrade this building to increase it's effect.";
        this.GetComponentInParent<BuildingsInterfaces>().UpdateMainText(_text);
    }
}
