using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Unit))]
public class PlayerInput : MonoBehaviour
{
    private Unit _unit;
    private ShipMovement _movementController;

    private void Awake()
    {
        _unit = GetComponent<Unit>();
        _movementController = GetComponent<ShipMovement>();
    }
    // Update is called once per frame
    private void Update()
    {
        CheckMovement();
        CheckAction();
    }

    private void CheckMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(moveHorizontal, moveVertical);

        _movementController.Move(direction);
    }

    private void CheckAction()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _unit.Action();
        }
    }


}
