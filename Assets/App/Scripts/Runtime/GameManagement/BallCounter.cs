using System;
using UnityEngine;
using UnityEngine.Serialization;

public class BallCounter : MonoBehaviour
{
    [Header("Settings")] 
    [SerializeField] private int maxBallTrough;
    private int _ballCounter;

    [Header("Input")]
    [SerializeField] private RSE_BallTrough rseBallTrough;
    [Header("Output")]
    [SerializeField] private RSE_BallCounterMax rseBallCounterMax;

    private void OnEnable() => rseBallTrough.action += IncrementBallCounter;
    private void OnDisable() => rseBallTrough.action -= IncrementBallCounter;
    
    /// <summary>
    /// When component enable, count ball trough and check if max ball trough
    /// </summary>
    private void IncrementBallCounter()
    {
        _ballCounter++;
        if (_ballCounter >= maxBallTrough) rseBallCounterMax.Call();
    }
}