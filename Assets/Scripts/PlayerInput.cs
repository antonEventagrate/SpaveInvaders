using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Unit))]
public class PlayerInput : MonoBehaviour
{
    private Unit _unit;

    private void Awake()
    {
        _unit = GetComponent<Unit>();
    }
    // Update is called once per frame
    private void Update()
    {
        CheckMovement();
        CheckAction();
    }

    private void CheckMovement()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(moveHorizontal, moveVertical).normalized;

        _unit.Move(direction);
    }

    private void CheckAction()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _unit.Action();
        }
    }


}
