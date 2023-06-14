using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ship : Unit
{
    [SerializeField][Range(0f, 15f)]
    private float _speed;
    private Rigidbody2D _rb;

    [SerializeField]
    private Ability Ability;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        Ability.Instantiate(this);
        _currentHelath = _maxHealth;
    }
    public void ChangeMainAbility(Ability ability)
    {
        Ability = ability;
        ability.Instantiate(this);
    }
    public override void Move(Vector2 direction)
    {
        float _moveHorizontal = direction.x;
        float _moveVertical = direction.y;
        transform.rotation = Quaternion.Euler(0, -direction.x * 25, 0);

        if (this.transform.position.x > 4.2f)
        {
            this.transform.position = new Vector3(4.2f, this.transform.position.y, this.transform.position.z);
            _moveHorizontal = Mathf.Clamp(_moveHorizontal, -1, 0);
        }
        if (this.transform.position.x < -4.2f)
        {
            this.transform.position = new Vector3(-4.2f, this.transform.position.y, this.transform.position.z);
            _moveHorizontal = Mathf.Clamp(_moveHorizontal, 0, 1);
        }
        if (this.transform.position.y > 7f)
        {
            this.transform.position = new Vector3(this.transform.position.x, 7f, this.transform.position.z);
            _moveVertical = Mathf.Clamp(_moveVertical, -1, 0);
        }
        if (this.transform.position.y < -7f)
        {
            this.transform.position = new Vector3(this.transform.position.x, -7f, this.transform.position.z);
            _moveVertical = Mathf.Clamp(_moveVertical, 0, 1);
        }

        direction = new Vector2(_moveHorizontal, _moveVertical);

        _rb.velocity = direction * _speed;
    }    
    public override void Action()
    {
        Ability.Invoke();
    }

    public override void TakeDamage(float damage)
    {
        _currentHelath -= damage;
        if(_currentHelath < 0)
        {
            Destroy(gameObject);
        }
    }
}
