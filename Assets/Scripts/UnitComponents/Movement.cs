using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    [SerializeField][Range(0f, 15f)]
    protected float _speed;
    public abstract void Move(Vector2 direction);
}
