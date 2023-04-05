using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Scriptable Unit")]
public class ScriptableUnit : ScriptableObject
{
    public Faction Faction;
    public Type Type;
    public BaseUnit UnitPrefab;
}

public enum Faction
{
    Hero = 0,
    Enemy = 1
}

public enum Type
{
    Hero1, 
    Hero2,
    Enemy1,
    Enemy2,
    Enemy3,
}