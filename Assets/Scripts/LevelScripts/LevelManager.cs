using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Stage[] _stages;
    [SerializeField]
    private SpawnData _playerSpawnData;

    [SerializeField]
    private int _untilNextStage = 0;
    private int _currentStageIndex = 0;
    //start game. spawn player wait for 

    public void Start()
    {
        SpawnPlayer();
        LoadStage(_stages[0]);
    }
    private void SpawnPlayer()
    {
        Unit unit = Instantiate(_playerSpawnData.UnitPrefab, _playerSpawnData.SpawnPosition, Quaternion.identity);
        unit.OnDestroyed.AddListener(OnPlayerKilled);
    }

    private void LoadStage(Stage stage)
    {
        _untilNextStage = stage.SpawnData.Length;
        foreach (SpawnData spawnData in stage.SpawnData)
        {
            Unit unit = Instantiate(spawnData.UnitPrefab, spawnData.SpawnPosition, Quaternion.identity);
            unit.OnDestroyed.AddListener(OnUnitKilled);
        }
    }
    private void OnPlayerKilled()
    {
        SceneManager.LoadScene(0);
    }
    private void OnUnitKilled()
    {
        _untilNextStage--;
        if( _untilNextStage <= 0)
        {
            LoadNextStage();
        }
    }
    private void LoadNextStage()
    {
        _currentStageIndex++;
        if(_currentStageIndex < _stages.Length)
        {
            LoadStage(_stages[_currentStageIndex]);
        }
        else
        {
            Debug.Log("Game ended");
        }
    }
    private void OnDestroy()
    {
        
    }

}
