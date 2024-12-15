using System;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private RSE_LaunchSession rseLaunchSession;
    [SerializeField] private RSE_BallCounterMax rseBallCounterMax;

    [Header("Ouput")]
    [SerializeField] private RSE_OpenPanel rseOpenPanel;

    private void OnEnable()
    {
        rseLaunchSession.action += OnSessionLaunched;
        rseBallCounterMax.action += EndSession;
    }

    private void OnDisable()
    {
        rseLaunchSession.action -= OnSessionLaunched;
        rseBallCounterMax.action -= EndSession;
    }

    private void OnSessionLaunched()
    {
        Debug.Log("Session Launched");
    }

    private void EndSession()
    {
        rseOpenPanel.Call("End");
    }
}