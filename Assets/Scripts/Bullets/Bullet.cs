using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Missle
{
    private ReloadTimer timer;
    public override void Initialize(Unit caster, float damage, float lifeDuration)
    {
        _caster = caster;
        _damage = damage;
        _lifeDuration = lifeDuration;
        timer = new ReloadTimer(_lifeDuration);
    }

    private void Update()
    {
        if (timer.CheckReload())
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Unit unit = other.GetComponent<Unit>();
        if (unit && unit.Side != _caster.Side)
        {
            other.GetComponent<Unit>().TakeDamage(_damage);
            Destroy(gameObject);
        }



    }
}
