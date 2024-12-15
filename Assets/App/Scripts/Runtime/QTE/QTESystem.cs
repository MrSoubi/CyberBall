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
    private bool QTERunning = false;

    [Header("References")]
    [SerializeField] private GameObject imageQTE;
    [SerializeField] private Slider sliderQTE;
    [SerializeField] private TextMeshProUGUI textQTE;
    [Header("RSO")]
    [SerializeField] private RSO_GameParameter gameParameter;
    [SerializeField] private RSO_ScoreMaxQTE scoreMaxQTE;
    [SerializeField] private RSO_CurrentScoreQTE currentScoreQTE;
    [SerializeField] private RSO_ValidKeyCodeQTE validKeyCodeQTE;
    [Header("Input")]
    [SerializeField] private RSE_QTECall eventQTECall;
    
    [Header("Output")]
    [SerializeField] private RSE_QTESucced eventQTESucced;
    [SerializeField] private RSE_QTEFailed eventQTEFailed;
    
    private void OnEnable()
    {
        eventQTECall.action += CheckLaunchQTE;
    }

    private void OnDisable()
    {
        eventQTECall.action -= CheckLaunchQTE;
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
                sliderQTE.value = currentScore;
                ChooseNextInput();
            }
            else
            {
                if (currentScore > 0)
                {
                    currentScore--;
                    currentScoreQTE.Value = currentScore;
                    sliderQTE.value = currentScore;
                    ChooseNextInput();
                }
                
            }

        }
        else
        {
            eventQTESucced.Call();
            QTERunning = false;
            imageQTE.SetActive(false);
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
        textQTE.text = validKeyCode.ToString();

    }

    public void CheckLaunchQTE()
    {
        if (gameParameter.Value.difficulty == difficulty_mode.HARD)
        {
            if (QTERunning) StopAllCoroutines();
            currentScore = 0;
            currentScoreQTE.Value = currentScore;
            sliderQTE.value = currentScore;
            sliderQTE.minValue = 0;
            sliderQTE.maxValue = scoreMax;
            QTERunning = true;
            imageQTE.SetActive(true);
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
        imageQTE.SetActive(false);
    }
}