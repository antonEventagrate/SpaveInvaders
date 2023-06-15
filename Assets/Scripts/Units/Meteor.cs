using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : Unit
{ 
    [SerializeField]
    private float _damage;
    private bool _isDestroyed = false;

    public void Awake()
    {
        _currentHelath = _maxHealth;
    }
    public override void Action()
    {
    }

    public override void TakeDamage(float damage)
    {
        if (_isDestroyed)
        {
            return;
        }
        _currentHelath -= damage;
        if (_currentHelath < 0)
        {
            Death();
        }
    }


    private void Death()
    {
        _isDestroyed = true;
        OnDead.Invoke();
        OnDestroyed.Invoke();
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Unit unit = other.GetComponent<Unit>();
        if (unit && unit.Side != Side)
        {
            _isDestroyed = true;
            unit.TakeDamage(_damage);
            OnDestroyed.Invoke();
            Destroy(gameObject);
        }
    }

    
}
