using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float speed;

    [Header("Input")]
    [SerializeField] private RSE_PlayerSelected playerSelectedRSE;
    [SerializeField] private RSO_PlayerSelectedPosition playerSelectedPositionRSO;

    private Vector3 posOrigin;
    private Vector3 posStart;
    private Vector3 posTarget;

    private void Start()
    {
        posOrigin = transform.position;
        posStart = transform.position;
    }

    private void OnEnable()
    {
        playerSelectedRSE.action += MoveBall;
    }

    private void OnDisable()
    {
        playerSelectedRSE.action -= MoveBall;
    }

    /// <summary>
    /// Move the Ball to the Next Position
    /// </summary>
    private void MoveBall()
    {
        posStart = transform.position;
        posTarget = playerSelectedPositionRSO.Value;

        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while(Vector3.Distance(transform.position, posTarget) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, posTarget, speed * Time.deltaTime);

            yield return null;
        }

        transform.position = posTarget;
    }
}