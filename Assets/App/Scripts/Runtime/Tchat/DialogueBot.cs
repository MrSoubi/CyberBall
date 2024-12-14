using TMPro;
using UnityEngine;
using System.Collections;
using System.Globalization;

public class DialogueBot : MonoBehaviour
{
    //[Header("Settings")]
    [SerializeField] string botName;
    //[Header("References")]
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] RSO_GameParameter RSO_GameParameter;
    [SerializeField] GameObject bubbleObject;

    [Space(10)]
    //RSO
    [SerializeField] private RSO_ListMessageOut ListMessageOut;
    // RSF
    // RSP

    //[Header("Input")]
    //[Header("Output")]
    [SerializeField] private RSE_OnBotMessageSend OnBotMessageSend;
    [SerializeField] RSE_AddGameAction rseAddGameAction;





    private Coroutine displayCoroutine;

    void Start()
    {
        bubbleObject.gameObject.SetActive(false);



        //OnBotSendText("text");
    }

    private void Update()
    {
        //Debug.Log("xxxx");

    }

    void DisplayDialogue(string text)
    {
        if (displayCoroutine != null)
            StopCoroutine(displayCoroutine);

        dialogueText.text = text;


        bubbleObject.gameObject.SetActive(true);

        displayCoroutine = StartCoroutine(HideBubbleAfterDelay(RSO_GameParameter.Value.default_chat_duration  /*2f*/));
    }

    IEnumerator HideBubbleAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        bubbleObject.gameObject.SetActive(false);

    }


    public void OnBotSendText(string text)
    {
        //Debug.Log(text);
        if (!string.IsNullOrEmpty(text))
        {
            //Debug.Log(text);

            DisplayDialogue(text);
            //var tchat = new TchatOut();



            //tchat.MessageContent = text;
            //ListMessageOut.Value.Add(tchat);

            GameAction action = new GameAction(botName, "sendMessage", "content:" + text);
            rseAddGameAction.Call(action);
        }
    }

    private void OnEnable()
    {
        OnBotMessageSend.action += OnBotSendText;
    }

    private void OnDisable()
    {
        OnBotMessageSend.action -= OnBotSendText;

    }
}