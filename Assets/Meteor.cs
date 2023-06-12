using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : Unit
{
    [SerializeField][Range(0f, 15f)]
    private float _speed;
    private Rigidbody2D _rb;
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

    public void OnDestroy()
    {
        Score.OnScoreAdded?.Invoke(25);
    }
}
