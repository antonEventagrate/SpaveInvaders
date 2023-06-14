using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : Unit
{ 
    [SerializeField][Range(0f, 15f)]
    private float _speed;
    private Rigidbody2D _rb;

    [SerializeField]
    private float _damage;

    public void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _currentHelath = _maxHealth;
    }
    public override void Action()
    {
    }

    public override void Move(Vector2 direction)
    {
        _rb.velocity = direction * _speed;
    }

    public override void TakeDamage(float damage)
    {
        _currentHelath -= damage;
        if (_currentHelath < 0)
        {
            Destroy(gameObject);
        }
    }



    public void OnTriggerEnter2D(Collider2D other)
    {
        Unit unit = other.GetComponent<Unit>();
        if (unit && unit.Side != Side)
        {
            unit.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
    
}
