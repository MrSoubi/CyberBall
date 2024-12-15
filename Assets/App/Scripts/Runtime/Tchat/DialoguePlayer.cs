using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class DialoguePlayer : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text dialoguePlayerText;
    [Header("References")]
    [SerializeField] RSO_GameParameter RSO_GameParameter;
    [SerializeField] TMP_Text textScrollView;
    [SerializeField] ScrollRect scrollRect;

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


        gameObject.SetActive(true);

        displayCoroutine = StartCoroutine(HideBubbleAfterDelay(RSO_GameParameter.Value.default_chat_message_duration));
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
            GameAction action = new GameAction("player2", "sendMessage", "content:" + userInput);
            rseAddGameAction.Call(action);

            textScrollView.text += $"[Player2]:\u00A0{userInput}\n";

            DisplayDialogue(userInput);
            inputField.text = "";

            //var tchat = new TchatOut();
            //tchat.MessageContent = userInput;
            //ListMessageOut.Value.Add(tchat);
            //scrollRect.verticalNormalizedPosition = 0;
            StartCoroutine(ChangeRect());

        }
    }

    IEnumerator ChangeRect()
    {
        yield return new WaitForEndOfFrame();
        scrollRect.verticalNormalizedPosition = 0;

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