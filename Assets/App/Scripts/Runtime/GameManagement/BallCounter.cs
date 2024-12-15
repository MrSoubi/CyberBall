using System;
using UnityEngine;
using UnityEngine.Serialization;

public class BallCounter : MonoBehaviour
{
    private int maxBallTrough;
    private int _ballCounter;

    [Header("Reference")]
    [SerializeField] private RSO_GameParameter rsoGameParametter;

    [Header("Input")]
    [SerializeField] private RSE_OnBallThrow rseBallTrough;
    [SerializeField] private RSE_SetupBot rseSetupBot;
    [SerializeField] RSO_BallThrowCount RSO_BallThrowCount;
    [SerializeField] RSE_Send send;
    [Header("Output")]
    [SerializeField] private RSE_BallCounterMax rseBallCounterMax;

    private void OnEnable()
    {
        rseBallTrough.action += IncrementBallCounter;
        rseSetupBot.action += SetupComponent;
    }

    private void OnDisable()
    {
        rseBallTrough.action -= IncrementBallCounter;
        rseSetupBot.action -= SetupComponent;
    }

    private void SetupComponent()
    {
        maxBallTrough = rsoGameParametter.Value.nb_throws;
    }

    /// <summary>
    /// When component enable, count ball trough and check if max ball trough
    /// </summary>
    private void IncrementBallCounter()
    {
        _ballCounter++;
        RSO_BallThrowCount.Value++;
        send.Call();
        if (_ballCounter >= maxBallTrough) rseBallCounterMax.Call();
    }

    private void OnDestroy()
    {
        RSO_BallThrowCount.Value = 0;
    }
}