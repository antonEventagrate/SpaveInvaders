using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDrop : MonoBehaviour
{
    [Range(0f, 1f)][SerializeField]
    private float _dropChance;
    [SerializeField]
    private AbilityPickUp[] _abilitiyPickUpPrefabs;
    private Unit _unit;
    private void Awake()
    {
        _unit = GetComponent<Unit>();
        _unit?.OnDead.AddListener(SpawnPickup);
    }
    private void SpawnPickup()
    {
        if (Random.Range(0f, 1f) < _dropChance)
        {
            int abilityIndex = Random.Range(0, _abilitiyPickUpPrefabs.Length);
            Instantiate(_abilitiyPickUpPrefabs[abilityIndex], transform.position, Quaternion.identity);
         
        }
    }
    private void OnDestroy()
    {
        _unit?.OnDead.RemoveListener(SpawnPickup);
    }

}
