using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float speed;

    [Header("Output")]
    [SerializeField] private RSO_PlayerName playerNameRSO;
    [SerializeField] private RSO_PlayerSelectedPosition playerSelectedPositionRSO;
    [SerializeField] private RSO_BallStartPosition ballStartPositionRSO;
    [SerializeField] private RSO_PlayerSelectedName playerSelectedNameRSO;
    [SerializeField] private RSE_AddGameAction addGameActionRSE;
    [SerializeField] private RSO_PlayerNameList _playerNameList;
    [SerializeField] private RSO_PlayerPositionList _playerPositionList;
    [SerializeField] private RSO_PlayerOffsetList _playerOffsetList;

    [Header("Input")]
    [SerializeField] private RSE_PlayerSelected playerSelectedRSE;
    [SerializeField] private RSE_BallCatch ballCatchRSE;
    [SerializeField] private RSE_OnBallThrow onBallThrowRSE;
    [SerializeField] private RSO_BallCurrentEntity ballCurrentEntityRSO;
    [SerializeField] private RSE_QTESucced qTESuccedRSE;
    [SerializeField] private RSE_QTEFailed qTEFailedRSE;

    private Vector3 posOrigin;
    private Vector3 posStart;
    private Vector3 posTarget;

    private void Start()
    {
        transform.position = ballStartPositionRSO.Value;

        posOrigin = transform.position;
        posStart = transform.position;
    }

    private void OnEnable()
    {
        playerSelectedRSE.action += MoveBall;
        qTESuccedRSE.action += MoveBall;

        qTEFailedRSE.action += TPBall;
    }

    private void OnDisable()
    {
        playerSelectedRSE.action -= MoveBall;
        qTESuccedRSE.action -= MoveBall;

        qTEFailedRSE.action -= TPBall;
    }

    /// <summary>
    /// Tp the Ball to a Random Bot
    /// </summary>
    private void TPBall()
    {
        ballCurrentEntityRSO.Value = null;

        posStart = transform.position;

        int index = Random.Range(0, _playerNameList.Value.Count);

        var random = _playerNameList.Value[index];

        while (playerNameRSO.Value == random)
        {
            index = Random.Range(0, _playerNameList.Value.Count);

            random = _playerNameList.Value[index];
        }

        var targetposition = _playerPositionList.Value[index];

        posTarget = targetposition - _playerOffsetList.Value[index];

        transform.position = posTarget;

        ballCurrentEntityRSO.Value = random;

        ballCatchRSE.Call();
    }

    /// <summary>
    /// Move the Ball to the Next Position
    /// </summary>
    private void MoveBall()
    {
        GameAction currentAction = new GameAction(ballCurrentEntityRSO.Value, "Throw", playerSelectedNameRSO.Value);
        addGameActionRSE.Call(currentAction);

        onBallThrowRSE.Call();

        ballCurrentEntityRSO.Value = null;

        posStart = transform.position;
        posTarget = playerSelectedPositionRSO.Value;

        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (Vector3.Distance(transform.position, posTarget) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, posTarget, speed * Time.deltaTime);

            yield return null;
        }

        transform.position = posTarget;

        ballCurrentEntityRSO.Value = playerSelectedNameRSO.Value;

        ballCatchRSE.Call();

        GameAction currentAction = new GameAction(ballCurrentEntityRSO.Value, "Catch");
        addGameActionRSE.Call(currentAction);
    }
}