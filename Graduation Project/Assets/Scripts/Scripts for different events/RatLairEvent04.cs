using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatLairEvent04 : MonoBehaviour
{
    public void FirstChoice()
    {
        InfoOnOwnedCharacters.Instance.UpdateOwned(5, true);
        GetComponentInParent<Event>().Choice01();
    }

    public void SecondChoice()
    {
        GetComponentInParent<Event>().Choice02();
    }
}
