using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Unit))]
public class MeteorController : MonoBehaviour
{
    private Unit _unit;

    private void Awake()
    {
        _unit = GetComponent<Unit>();
    }
    // Update is called once per frame
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _unit.Move(Vector2.down);
    }
}
