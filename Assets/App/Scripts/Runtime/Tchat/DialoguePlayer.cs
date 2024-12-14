using System.Collections;
using TMPro;
using UnityEngine;
public class DialoguePlayer : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private RectTransform dialogueBubble;
    [SerializeField] private TMP_Text dialoguePlayerText;
    [Header("References")]
    [SerializeField] private Vector2 padding;
    [SerializeField] private RSO_ListMessageOut ListMessageOut;
    //[Space(10)]
    // RSO
    // RSF
    // RSP

    //[Header("Input")]
    [Header("Output")]
    [SerializeField] private RSE_OnMessageSend OnPlayerMessageSend;
    [SerializeField] RSE_AddGameAction rseAddGameAction;





    private Coroutine displayCoroutine;

    void Start()
    {
        
    }

    void DisplayDialogue(string text)
    {
        if (displayCoroutine != null)
            StopCoroutine(displayCoroutine);

        dialoguePlayerText.text = text;

        dialoguePlayerText.ForceMeshUpdate();
        Vector2 textSize = dialoguePlayerText.GetRenderedValues(false);
        dialogueBubble.sizeDelta = textSize + padding;

        gameObject.SetActive(true);

        displayCoroutine = StartCoroutine(HideBubbleAfterDelay(2f));
    }

    IEnumerator HideBubbleAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
        inputField.text = "";

    }

    public void OnSendText()
    {
        string userInput = inputField.text;

        

        if (!string.IsNullOrEmpty(userInput))
        {
            GameAction action = new GameAction("player 1", "sendMessage", "content:" + userInput);
            rseAddGameAction.Call(action);


            DisplayDialogue(userInput);
            inputField.text = "";

            var tchat = new TchatOut();
            tchat.MessageContent = userInput;
            ListMessageOut.Value.Add(tchat);
        }
    }

    


    private void OnEnable()
    {
        //OnPlayerMessageSend.action += OnSendText;
    }

    private void OnDisable()
    {
        //OnPlayerMessageSend.action -= OnSendText;

    }

}