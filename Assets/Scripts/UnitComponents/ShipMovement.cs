using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : Movement
{
    [SerializeField]
    private Vector2 _minBorder;
    [SerializeField]
    private Vector2 _maxBorder;
    private Rigidbody2D _rb;
    [SerializeField]

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    public override void Move(Vector2 direction)
    {
        float _moveHorizontal = direction.x;
        float _moveVertical = direction.y;
        transform.rotation = Quaternion.Euler(0, -direction.x * 25, 0);

        if (this.transform.position.x > _maxBorder.x)
        {
            this.transform.position = new Vector3(_maxBorder.x, this.transform.position.y, this.transform.position.z);
            _moveHorizontal = Mathf.Clamp(_moveHorizontal, -1, 0);
        }
        if (this.transform.position.x < _minBorder.x)
        {
            this.transform.position = new Vector3(_minBorder.x, this.transform.position.y, this.transform.position.z);
            _moveHorizontal = Mathf.Clamp(_moveHorizontal, 0, 1);
        }
        if (this.transform.position.y > _maxBorder.y)
        {
            this.transform.position = new Vector3(this.transform.position.x, _maxBorder.y, this.transform.position.z);
            _moveVertical = Mathf.Clamp(_moveVertical, -1, 0);
        }
        if (this.transform.position.y < _minBorder.y)
        {
            this.transform.position = new Vector3(this.transform.position.x, _minBorder.y, this.transform.position.z);
            _moveVertical = Mathf.Clamp(_moveVertical, 0, 1);
        }

        direction = new Vector2(_moveHorizontal, _moveVertical);

        _rb.velocity = direction * _speed;
    }
}
