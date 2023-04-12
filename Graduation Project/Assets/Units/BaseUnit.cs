using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    public string UnitName;
    public Tile occupiedTile;
    public Faction Faction;
    public Type Type;
    public float Health;
    public float BaseHealth;

    [SerializeField] private HealthBarBehaviour _healthBar;

    private void Start()
    {
        if (this.Faction == Faction.Hero)
        {
            BaseHero hero = (BaseHero)this;
            if (hero.isWounded)
            {
                Health = BaseHealth * 0.5f;
                _healthBar.UpdateHealthBar(BaseHealth, Health);
            }
            else
            {
                Health = BaseHealth;
                _healthBar.UpdateHealthBar(BaseHealth, Health);
            }
        }
        else
        {
            Health = BaseHealth;
            _healthBar.UpdateHealthBar(BaseHealth, Health);
        }
    }

    public void TakeDamage(float multiply)
    {
        Health -= 10f * multiply;
        _healthBar.UpdateHealthBar(BaseHealth, Health);
    }
}