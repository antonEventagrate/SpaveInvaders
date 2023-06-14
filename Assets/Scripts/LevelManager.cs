using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private SpawnData[] _spawnData;
    public void Start()
    {
        SpawnUnits();
    }
    private void SpawnUnits()
    {
        foreach(SpawnData spawnData in _spawnData)
        {
            Instantiate(spawnData.UnitPrefab, spawnData.SpawnPosition, Quaternion.identity);
        }
    }
}
