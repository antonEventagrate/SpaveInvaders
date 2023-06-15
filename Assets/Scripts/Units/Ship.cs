using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : Unit
{
    [SerializeField]
    private Ability Ability;

    

    private void Awake()
    {
        Ability.Instantiate(this);
        _currentHelath = _maxHealth;
    }
    public void ChangeMainAbility(Ability ability)
    {
        Ability = ability;
        ability.Instantiate(this);
    }
       
    public override void Action()
    {
        Ability.Invoke();
    }

    public override void TakeDamage(float damage)
    {
        _currentHelath -= damage;
        if(_currentHelath < 0)
        {
            Death();
        }
    }
    private void Death()
    {
        OnDead.Invoke();
        OnDestroyed.Invoke();
        Destroy(gameObject);
    }
}
