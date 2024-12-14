using TMPro;
using UnityEngine;
using System.Collections;
using System.Globalization;

public class DialogueBot : MonoBehaviour
{
    //[Header("Settings")]
    [SerializeField] private Vector2 padding;
    [SerializeField] string nameBot;

    //[Header("References")]
    [SerializeField] private RectTransform dialogueBubble;
    [SerializeField] private TMP_Text dialogueText;
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
        
    }

    void DisplayDialogue(string text)
    {
        if (displayCoroutine != null)
            StopCoroutine(displayCoroutine);

        dialogueText.text = text;

        dialogueText.ForceMeshUpdate();
        Vector2 textSize = dialogueText.GetRenderedValues(false);
        dialogueBubble.sizeDelta = textSize + padding;

        gameObject.SetActive(true);

        displayCoroutine = StartCoroutine(HideBubbleAfterDelay(2f));
    }

    IEnumerator HideBubbleAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);

    }


    public void OnBotSendText(string text)
    {

        if (!string.IsNullOrEmpty(text))
        {
            DisplayDialogue(text);
            var tchat = new TchatOut();



            tchat.MessageContent = text;
            ListMessageOut.Value.Add(tchat);

            GameAction action = new GameAction(nameBot, "sendMessage", "content:" + text);
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