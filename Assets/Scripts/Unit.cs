using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public byte Side => _side;
    [SerializeField]
    private byte _side;

    [SerializeField]
    protected float _maxHealth;
    [SerializeField]
    protected float _currentHelath;

    public abstract void TakeDamage(float damage);
    public abstract void Move(Vector2 direction);
    public abstract void Action();

}
