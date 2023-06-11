using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossroadsEvent03 : MonoBehaviour
{
    public void FirstChoice()
    {
        InfoOnOwnedCharacters.Instance.UpdateOwned(3, true);
        GetComponentInParent<Event>().Choice01();

    }

    public void SecondChoice()
    {
        GetComponentInParent<Event>().Choice02();
    }
}
