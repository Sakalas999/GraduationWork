using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealersHut : MonoBehaviour
{
    private string _text;

    public void UpdateText()
    {
        int count = 0;
        if (InfoOnOwnedCharacters.Instance.isWoundedH1) count++;
        if (InfoOnOwnedCharacters.Instance.isWoundedH2) count++;
        if (InfoOnOwnedCharacters.Instance.isWoundedH3) count++;
        if (InfoOnOwnedCharacters.Instance.isWoundedH4) count++;
        if (InfoOnOwnedCharacters.Instance.isWoundedH5) count++;

        _text = "This is the healer's hut. For 5 cheese you heal one of your characters. Currently there are " + count + 
            " wounded characters. It will cost a total of " + count * 5 + " cheese to heal all of your characters.";
        this.GetComponentInParent<BuildingsInterfaces>().UpdateMainText(_text);
    }
}
