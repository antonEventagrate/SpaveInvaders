using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPickUp : MonoBehaviour
{
    [SerializeField]
    private Ability _ability;

    public void SetAbility(Ability ability)
    {
        _ability = ability;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Ship ship = other.GetComponent<Ship>();
        if (ship)
        {
            ship.ChangeMainAbility(_ability);
            Destroy(gameObject);
        }
    }
}
