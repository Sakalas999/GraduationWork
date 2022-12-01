using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    public string UnitName;
    public Tile occupiedTile;
    public Faction Faction;
    public float Health;
    public float BaseHealth;

    [SerializeField] private HealthBarBehaviour _healthBar;

    private void Start()
    {
        Health = BaseHealth;
        _healthBar.UpdateHealthBar(BaseHealth, Health);
    }

    public void TakeDamage()
    {
        Health -= 10f;
        _healthBar.UpdateHealthBar(BaseHealth, Health);
    }
}