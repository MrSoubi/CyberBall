using System.Collections;
using UnityEditor.XR;
using UnityEngine;
public class Bot : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] SSO_CooldownBeforeThrowBall _coolDownBeforeThrow;
    [SerializeField] int _botId;
    [SerializeField] RSO_PlayerNameList _playerNameList;
    [SerializeField] RSO_PlayerPositionList _playerPositionList;

  
    [SerializeField] private Vector3 offset;

    [Header("Output")]
    [SerializeField] private RSO_PlayerSelectedName playerSelectedNameRSO;
    [SerializeField] private RSO_PlayerSelectedPosition playerSelectedPositionRSO;
    [SerializeField] private RSE_PlayerSelected playerSelectedRSE;
    [Header("References")]
    //[SerializeField] HaveBall haveBall;
    //[Space(10)]
    // RSO
    [SerializeField] RSO_BallCurrentEntity RSO_BallCurrentEntity;
    // RSF
    // RSP

    //[Header("Input")]
    [SerializeField] private RSE_BallCatch ballCatchRSE;

    //[Header("Output")]


    public bool HadBall { get; set; } = false;

    private void Start()
    {
        StartDelayBefore();
    }
    public void StartDelayBefore()
    {
        if (RSO_BallCurrentEntity.Value == gameObject.name)
        {
            StartCoroutine(CooldownBeforeThrow());

        }
    }
    IEnumerator CooldownBeforeThrow()
    {
        yield return new WaitForSeconds(Random.Range(_coolDownBeforeThrow.MinTime, _coolDownBeforeThrow.MaxTime));
        GetRandomTarget();
    }

    public void GetRandomTarget()
    {
        int index = Random.Range(0, _playerNameList.Value.Count);
        var random = _playerNameList.Value[index];

        if (random == null || gameObject.name == random)
        {
            GetRandomTarget();
        }

        var targetposition = _playerPositionList.Value[index];

        playerSelectedNameRSO.Value = random;
        playerSelectedPositionRSO.Value = targetposition - offset;

        playerSelectedRSE.Call();
    }

    private void OnEnable()
    {
        ballCatchRSE.action += StartDelayBefore;
    }

    private void OnDisable()
    {
        ballCatchRSE.action -= StartDelayBefore;
    }
}