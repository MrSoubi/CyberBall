using UnityEngine;

public class HaveBall : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private bool haveBall;
    [SerializeField] private bool isPlayer;
    [SerializeField] private Vector3 offset;

    [Header("Output")]
    [SerializeField] private RSO_PlayerName playerNameRSO;
    [SerializeField] private RSO_PlayerNameList playerNameListRSO;
    [SerializeField] private RSO_PlayerPositionList playerPositionListRSO;
    [SerializeField] private RSO_BallCurrentEntity ballCurrentEntityRSO;
    [SerializeField] private RSO_BallStartPosition ballStartPositionRSO;

    private void Awake()
    {
        playerNameListRSO.Value.Add(gameObject.name);
        playerPositionListRSO.Value.Add(transform.position - offset);

        if (haveBall)
        {
            ballCurrentEntityRSO.Value = gameObject.name;
            ballStartPositionRSO.Value = transform.position - offset;
        }

        if (isPlayer)
        {
            playerNameRSO.Value = gameObject.name;
        }
    }

    private void OnDisable()
    {
        playerNameListRSO.Value.Clear();
    }
}