using Sirenix.OdinInspector;
using UnityEngine;

public class SelectPlayer : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private string nameEntity;

    [Header("Output")]
    [SerializeField] private RSO_PlayerSelectedName playerSelectedNameRSO;
    [SerializeField] private RSO_PlayerSelectedPosition playerSelectedPositionRSO;
    [SerializeField] private RSE_PlayerSelected playerSelectedRSE;

    private void OnMouseDown()
    {
        SetTarget();

    }

    /// <summary>
    /// Set the Target Selected
    /// </summary>
    [Button]
    private void SetTarget()
    {
        playerSelectedNameRSO.Value = nameEntity;
        playerSelectedPositionRSO.Value = transform.position;

        playerSelectedRSE.Call();
    }
}
