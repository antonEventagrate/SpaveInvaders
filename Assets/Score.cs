using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Score : MonoBehaviour
{
    private int _score;
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    public static UnityEvent<int> OnScoreAdded = new UnityEvent<int>();

    public void Awake()
    {
        OnScoreAdded.AddListener(AddScore);
    }
    public void AddScore(int score)
    {
        _score += score;
        _scoreText.text = $"Score : {_score}";
    }

    public void OnDestroy()
    {
        OnScoreAdded.RemoveListener(AddScore);
    }
}
