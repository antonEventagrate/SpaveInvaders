using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Missle : MonoBehaviour
{
    public abstract void Initialize(Unit caster, float damage, float lifeDuration);
    protected float _damage;
    protected Unit _caster;
    protected float _lifeDuration;
}
