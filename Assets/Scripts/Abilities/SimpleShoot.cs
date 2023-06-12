using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Shoot", menuName = "Abilities/Shoot")]
public class SimpleShoot : Ability
{
    

    private Unit _caster;
    [SerializeField]
    private float _reloadTime;
    private float _timerEnd;

    [SerializeField]
    private Missle _bulletPrefab;
   
    [SerializeField]
    private float _damage;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private bool _canPenetrate;
    [SerializeField]
    private float _bulletLife;
  
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
            Missle obj = Instantiate(_bulletPrefab, _caster.transform.position, _caster.transform.rotation);
            obj.GetComponent<Rigidbody2D>().velocity = obj.transform.up * _speed;
            obj.Initialize(_caster, _damage, _bulletLife);

            _reloadTimer.ResetTimer();

        }
    }

}
