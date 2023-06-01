using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoutsHut : MonoBehaviour
{
    private string _text;

    public void UpdateText()
    {
        _text = "The Armory is currently " + BuildingManager.Instance.SHLevel + " level. Current level provides " +
               BuildingManager.Instance.SHLevel * 1 + " percentage less likely to be raided. For 5 cheese you can upgrade this building to increase it's effect.";
        this.GetComponentInParent<BuildingsInterfaces>().UpdateMainText(_text);
    }
}
