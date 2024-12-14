using UnityEngine;

public class HaveBall : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private bool haveBall;
    [SerializeField] private Vector3 offset;

    [Header("Output")]
    [SerializeField] private RSO_PlayerNameList playerNameListRSO;
    [SerializeField] private RSO_BallCurrentEntity ballCurrentEntityRSO;
    [SerializeField] private RSO_BallStartPosition ballStartPositionRSO;

    private void Awake()
    {
        playerNameListRSO.Value.Add(gameObject.name);

        if (haveBall)
        {
            ballCurrentEntityRSO.Value = gameObject.name;
            ballStartPositionRSO.Value = transform.position - offset;
        }
    }

    private void OnDisable()
    {
        playerNameListRSO.Value.Clear();
    }
}