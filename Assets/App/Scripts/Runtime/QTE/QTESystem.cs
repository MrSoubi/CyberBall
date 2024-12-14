using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class QTESystem : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private List<KeyCode> input = new List<KeyCode>();
    [SerializeField] private float countdownQTE;
    private int scoreMax = 5;
    private int currentScore;
    private KeyCode validKeyCode;
    private bool hasQTE = true;
    private bool QTERunning = false;

    //[Header("References")]

    [Header("Input")]
    [SerializeField] private RSE_PlayerSelected eventPlayerSelected;

    [Header("Output")]
    [SerializeField] private RSE_QTESucced eventQTESucced;
    [SerializeField] private RSE_QTEFailed eventQTEFailed;
    [SerializeField] private RSO_ScoreMaxQTE scoreMaxQTE;
    [SerializeField] private RSO_CurrentScoreQTE currentScoreQTE;
    [SerializeField] private RSO_ValidKeyCodeQTE validKeyCodeQTE;
    private void OnEnable()
    {
        eventPlayerSelected.action += CheckLaunchQTE;
    }

    private void OnDisable()
    {
        eventPlayerSelected.action -= CheckLaunchQTE;
    }
    private void Start()
    {
        scoreMax = 5;
        scoreMaxQTE.Value = scoreMax;
    }
    private void Update()
    {
        if (QTERunning) QTEAction();
    }

    //Lance le QTE
    void QTEAction()
    {
        if (currentScore < scoreMax)
        {
            if (!Input.anyKeyDown) return;
            if (Input.GetKeyDown(validKeyCode))
            {
                currentScore++;
                currentScoreQTE.Value = currentScore;
                ChooseNextInput();
            }
            else
            {
                if (currentScore > 0)
                {
                    currentScore--;
                    currentScoreQTE.Value = currentScore;
                    ChooseNextInput();
                }
                
            }

        }
        else
        {
            eventQTESucced.Call();
            QTERunning = false;
            StopAllCoroutines();
            scoreMax = 10;
            scoreMaxQTE.Value = scoreMax;
            countdownQTE = 5;
        }
        
    }

    //Choisit le prochain input pour le QTE
    void ChooseNextInput()
    {
        int keyCode = Random.Range(0, input.Count);
        validKeyCode = input[keyCode];
        validKeyCodeQTE.Value = validKeyCode;

    }

    public void CheckLaunchQTE()
    {
        if (hasQTE)
        {
            if (QTERunning) StopAllCoroutines();
            currentScore = 0;
            currentScoreQTE.Value = currentScore;
            QTERunning = true;
            StartCoroutine(StartQTECountdown(countdownQTE));
            ChooseNextInput();
        }
        else
        {
            eventQTESucced.Call();
        }
    }

    //Compte à rebours du QTE
    IEnumerator StartQTECountdown(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        eventQTEFailed.Call();
        QTERunning = false;
    }
}