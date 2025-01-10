using UnityEngine;

public class HaveBall : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private bool startBall;
    [SerializeField] private bool isPlayer;
    [SerializeField] private Vector3 offset;

    [Header("Output")]
    [SerializeField] private RSO_PlayerName playerNameRSO;
    [SerializeField] private RSO_PlayerNameList playerNameListRSO;
    [SerializeField] private RSO_PlayerPositionList playerPositionListRSO;
    [SerializeField] private RSO_PlayerOffsetList playerOffsetListRSO;
    [SerializeField] private RSO_BallCurrentEntity ballCurrentEntityRSO;
    [SerializeField] private RSO_BallStartPosition ballStartPositionRSO;
    [SerializeField] private RSO_DictBallCount dictBallReceiveCountRSO;

    private void Awake()
    {
        if (playerNameListRSO.Value == null) playerNameListRSO.Value = new();
        if (playerPositionListRSO.Value == null) playerPositionListRSO.Value = new();
        if (playerOffsetListRSO.Value == null) playerOffsetListRSO.Value = new();
        if (dictBallReceiveCountRSO.Value == null) dictBallReceiveCountRSO.Value = new();
        
        playerNameListRSO.Value.Add(gameObject.name);
        playerPositionListRSO.Value.Add(transform.position);
        playerOffsetListRSO.Value.Add(offset);
        dictBallReceiveCountRSO.Value.Add(gameObject.name, 0);


        if (startBall)
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
        playerPositionListRSO.Value.Clear();
        playerOffsetListRSO.Value.Clear();
        dictBallReceiveCountRSO.Value.Clear();
    }
}