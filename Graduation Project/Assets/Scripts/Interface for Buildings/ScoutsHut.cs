using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoutsHut : MonoBehaviour
{
    private string _text;

    public void UpdateText()
    {
        if (BuildingManager.Instance.SHLevel < 5)
        {
            _text = "The Armory is currently " + BuildingManager.Instance.SHLevel + " level. Current level provides " +
                   BuildingManager.Instance.SHLevel * 5 + " percentage less likely to be raided. For 5 cheese you can upgrade this building to increase it's effect.";
            this.GetComponentInParent<BuildingsInterfaces>().UpdateMainText(_text);
        }
        else
        {
            GetComponentInParent<BuildingsInterfaces>().HideUpgrade();

            _text = "The Armory is currently at the maximum level of " + BuildingManager.Instance.SHLevel + ". Current level provides " +
       BuildingManager.Instance.SHLevel * 5 + " percentage less likely to be raided.";
            this.GetComponentInParent<BuildingsInterfaces>().UpdateMainText(_text);
        }
    }
}
