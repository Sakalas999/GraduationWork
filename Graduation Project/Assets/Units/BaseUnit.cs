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

    [SerializeField] private GameObject _blood;

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

    public void TakeDamage(float damage)
    {
        _blood.GetComponent<ParticleSystem>().Play();

        Health -= damage;
        _healthBar.UpdateHealthBar(BaseHealth, Health);
    }
}