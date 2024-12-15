using Sirenix.OdinInspector;
using UnityEngine;

public class SelectPlayer : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Vector3 offset;

    [Header("Output")]
    [SerializeField] private RSO_PlayerSelectedName playerSelectedNameRSO;
    [SerializeField] private RSO_PlayerSelectedPosition playerSelectedPositionRSO;
    [SerializeField] private RSE_QTECall qTECallRSE;
    [SerializeField] private RSO_BallCurrentEntity ballCurrentEntityRSO;
    [SerializeField] private RSO_PlayerName playerNameRSO;

    private void OnMouseDown()
    {
        SetTarget();
    }

    /// <summary>
    /// Set the Target Selected
    /// </summary>
    private void SetTarget()
    {
        if(ballCurrentEntityRSO.Value == playerNameRSO.Value)
        {
            playerSelectedNameRSO.Value = gameObject.name;
            playerSelectedPositionRSO.Value = transform.position - offset;

            qTECallRSE.Call();
        }
    }
}
