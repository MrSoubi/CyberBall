using System;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private RSE_LaunchSession rseLaunchSession;

    private void OnEnable() => rseLaunchSession.action += OnSessionLaunched;
    private void OnDisable() => rseLaunchSession.action -= OnSessionLaunched;
    
    private void OnSessionLaunched()
    {
        Debug.Log("Session Launched");
    }
}