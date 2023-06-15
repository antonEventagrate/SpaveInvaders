using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScore : MonoBehaviour
{
    [SerializeField]
    private int _score;
    private Unit _unit;
    private void Awake()
    {
        _unit = GetComponent<Unit>();
        _unit?.OnDead.AddListener(AddScore);
    }

    private void AddScore()
    {
        Score.OnScoreAdded?.Invoke(_score);
    }
    private void OnDestroy()
    {
    }
}
