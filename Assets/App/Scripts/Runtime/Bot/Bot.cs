using System.Collections;
using System.Linq;
using UnityEditor.XR;
using UnityEngine;
public class Bot : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] SSO_CooldownBeforeThrowBall _coolDownBeforeThrow;
    [SerializeField] RSO_PlayerNameList _playerNameList;
    [SerializeField] RSO_PlayerPositionList _playerPositionList;
    [SerializeField] RSO_PlayerOffsetList _playerOffsetList;
    [SerializeField] private RSO_PlayerName playerNameRSO;
    [SerializeField] private RSO_DictBallCount dictBallReceiveCountRSO;






    [Header("Output")]
    [SerializeField] private RSO_PlayerSelectedName playerSelectedNameRSO;
    [SerializeField] private RSO_PlayerSelectedPosition playerSelectedPositionRSO;
    [SerializeField] private RSE_PlayerSelected playerSelectedRSE;
    [Header("References")]
    [SerializeField] RSO_GameParameter RSO_GameParameter;

    //[Space(10)]
    // RSO
    [SerializeField] RSO_BallCurrentEntity RSO_BallCurrentEntity;
    // RSF
    // RSP

    //[Header("Input")]
    [SerializeField] private RSE_BallCatch ballCatchRSE;



    //[Header("Output")]

    public bool HadBall { get; set; } = false;

    public bool throwBall;

    private void Start()
    {
        StartDelayBefore();

        
    }

    public void StartDelayBefore()
    {
        if (RSO_BallCurrentEntity.Value == gameObject.name && !throwBall)
        {
            throwBall = true;

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
        dictBallReceiveCountRSO.Value[gameObject.name]++;

        if (RSO_GameParameter.Value.inclusivity == inclusivity_mode.INCLUSIF)
        {
            var differentKeys = dictBallReceiveCountRSO.Value.Keys.Where(key => key != gameObject.name);
            var smallestKey = differentKeys.OrderBy(key => dictBallReceiveCountRSO.Value[key]).FirstOrDefault();
            int indexToHit = _playerNameList.Value.IndexOf(smallestKey);

            var targetpositionNormal = _playerPositionList.Value[indexToHit];
            Debug.Log($"Count Smallest Value: {dictBallReceiveCountRSO.Value[smallestKey]}");
            playerSelectedNameRSO.Value = smallestKey;
            playerSelectedPositionRSO.Value = targetpositionNormal - _playerOffsetList.Value[indexToHit];

            playerSelectedRSE.Call();

            throwBall = false;

            return;
        }
        else if(RSO_GameParameter.Value.inclusivity == inclusivity_mode.EXCLUSIF)
        {
            if (dictBallReceiveCountRSO.Value[playerNameRSO.Value] >= 2)
            {
                var differentKeys = dictBallReceiveCountRSO.Value.Keys.Where(key => key != gameObject.name && key != playerNameRSO.Value);
                var smallestKey = differentKeys.OrderBy(key => dictBallReceiveCountRSO.Value[key]).FirstOrDefault();
                int indexToHit = _playerNameList.Value.IndexOf(smallestKey);

                var targetpositionNormal = _playerPositionList.Value[indexToHit];

                playerSelectedNameRSO.Value = smallestKey;
                playerSelectedPositionRSO.Value = targetpositionNormal - _playerOffsetList.Value[indexToHit];

                playerSelectedRSE.Call();

                throwBall = false;
                return;

            }
            else {
                int index = Random.Range(0, _playerNameList.Value.Count);

                var random = _playerNameList.Value[index];



                while (random == null || gameObject.name == random)
                {
                    index = Random.Range(0, _playerNameList.Value.Count);

                    random = _playerNameList.Value[index];
                }

                var targetposition = _playerPositionList.Value[index];

                playerSelectedNameRSO.Value = random;
                playerSelectedPositionRSO.Value = targetposition - _playerOffsetList.Value[index];

                playerSelectedRSE.Call();

                throwBall = false;
                return;
            }
        }

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