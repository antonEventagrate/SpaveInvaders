using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Unit : MonoBehaviour
{
    public byte Side => _side;
    [SerializeField]
    private byte _side;

    [SerializeField]
    protected float _maxHealth;
    [SerializeField]
    protected float _currentHelath;
    public UnityEvent OnDead = new UnityEvent();
    public UnityEvent OnDestroyed = new UnityEvent();

    public abstract void TakeDamage(float damage);
    
    public abstract void Action();

    private void OnDestroy()
    {
        OnDead.RemoveAllListeners();
        OnDestroyed.RemoveAllListeners();
    }

}
