using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Shoot", menuName = "Abilities/SpreadShoot")]
public class SpreadShoot : Ability
{
    

    private Unit _caster;
    [SerializeField]
    private float _reloadTime;
    private float _timerEnd;

    [SerializeField]
    private Missle _bulletPrefab;


    [SerializeField]
    private int _numberOfShoots;
    [SerializeField]
    private float _damage;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private bool _canPenetrate;
    [SerializeField]
    private float _bulletLife;
    [SerializeField]
    private float _angleBerweenBullets;

    private ReloadTimer _reloadTimer;
    public override void Instantiate(Unit unit)
    {
        _caster = unit;
        _reloadTimer = new ReloadTimer(_reloadTime);
    }

    public override void Invoke()
    {
        if (_reloadTimer.CheckReload())
        {
            for (int i = 0; i < _numberOfShoots; i++)
            {
                Quaternion angle = _caster.transform.rotation;
                if (_numberOfShoots % 2 == 0)
                {
                    angle = Quaternion.Euler(0, 0, (i - (_numberOfShoots / 2 - 0.5f)) * _angleBerweenBullets);
                }
                else
                {
                    angle = Quaternion.Euler(0, 0, (i - _numberOfShoots / 2) * _angleBerweenBullets);
                }
                Missle obj = Instantiate(_bulletPrefab, _caster.transform.position, angle * _caster.transform.rotation);
                obj.Initialize(_caster, _damage, _bulletLife);
                obj.GetComponent<Rigidbody2D>().velocity = obj.transform.up * _speed;
            }
            _reloadTimer.ResetTimer();
        }
    }

}
