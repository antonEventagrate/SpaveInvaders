using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScore : MonoBehaviour
{
    [SerializeField]
    private int _score;
    public void OnDestroy()
    {
        Score.OnScoreAdded?.Invoke(_score);
    }
}
