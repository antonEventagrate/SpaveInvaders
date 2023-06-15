using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : Missle
{
    private LineRenderer _line;
    private ReloadTimer timer;

    public void Awake()
    {
        _line = GetComponent<LineRenderer>();
    }
    public override void Initialize(Unit caster, float damage, float lifeDuration)
    {
        _caster = caster;
        _damage = damage;
        _lifeDuration = lifeDuration;
        timer = new ReloadTimer(_lifeDuration);
    }

    // Update is called once per frame
    private void Update()
    {
        if (timer.CheckReload())
        {
            Destroy(gameObject);
            return;
        }


        //_line.SetPosition(1, new Vector3(0, 50, -0.5f));
        if (_caster)
        {
            transform.position = _caster.transform.position;
        }
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.up, 100f);

        foreach (RaycastHit2D hit in hits)
        {
            Unit obj = hit.collider.GetComponent<Unit>();
            if (obj)
            {
                if (obj.Side != _caster.Side)
                {
                    obj.TakeDamage(_damage);
                    //_line.SetPosition(1, new Vector3(0, hit.distance, -0.5f));
                }
            }
        }
    }
}
