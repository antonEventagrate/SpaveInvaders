using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GenerealMovement : Movement
{
    private Rigidbody2D _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    public override void Move(Vector2 direction)
    {
        _rb.velocity = direction * _speed;
    }
}
