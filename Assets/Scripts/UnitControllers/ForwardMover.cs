using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class ForwardMover : MonoBehaviour
{
    private Movement _movement;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
    }
    // Update is called once per frame
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _movement.Move(Vector2.down);
    }
}
