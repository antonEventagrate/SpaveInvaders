using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Ability: ScriptableObject
{
    public abstract void Instantiate(Unit unit);
    public abstract void Invoke();

    
}
