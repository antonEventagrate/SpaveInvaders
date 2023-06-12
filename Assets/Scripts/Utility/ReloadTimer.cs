using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadTimer
{
    private float _reloadTime;
    private float _timerEnd;

    public ReloadTimer(float reloadTime)
    {
        _reloadTime = reloadTime;
        _timerEnd = Time.time + reloadTime;
    }

    public void ResetTimer()
    {
        _timerEnd = Time.time + _reloadTime;
    }
    public bool CheckReload()
    {
        return Time.time >= _timerEnd;
    }
}
