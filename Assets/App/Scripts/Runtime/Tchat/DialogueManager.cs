using System.Collections.Generic;
using UnityEngine;
public class DialogueManager : MonoBehaviour
{
    //[Header("Settings")]
    [SerializeField] int idBot1;
    [SerializeField] int idBot2;
    //[Header("References")]
    [SerializeField] RSO_GameParameter RSO_GameParameter;
    [SerializeField] GameObject GameTchat;
    [SerializeField] private RSE_OnBotMessageSend OnBot1MessageSend;
    [SerializeField] private RSE_OnBotMessageSend OnBot2MessageSend;

    //[Space(10)]
    // RSO
    [SerializeField] RSO_BallThrowCount RSO_BallThrowCount;
    // RSF
    // RSP

    //[Header("Input")]
    [SerializeField] RSE_Send send;

    //[Header("Output")]

    private List<Comment> commentsBot1 = new List<Comment>();
    private List<Comment> commentsBot2 = new List<Comment>();

    private void Start()
    {
        if (RSO_GameParameter.Value.is_chat_enabled == true)
        {
            GameTchat.SetActive(true);

        }
        else
        {
            GameTchat.SetActive(false);
        }

        //Comment[] comments = RSO_GameParameter.Value.comments;

        //Dictionary<int, List<Comment>> groupedComments = new Dictionary<int, List<Comment>>();

        //foreach (var comment in comments)
        //{
        //    if (!groupedComments.ContainsKey(comment.bot_id))
        //    {
        //        groupedComments[comment.bot_id] = new List<Comment>();
        //    }

        //    groupedComments[comment.bot_id].Add(comment);
        //}

        //foreach (var kvp in groupedComments)
        //{
        //    int botId = kvp.Key;
        //    List<Comment> botComments = kvp.Value;
        //}

        foreach (var comment in RSO_GameParameter.Value.comments)
        {
            if(comment.bot_id == idBot1)
            {
                commentsBot1.Add(comment);
            }
            else if (comment.bot_id == idBot2)
            {
                commentsBot2.Add(comment);
            }
        }
        //var commente = new Comment();
        //commente.bot_id = 0;
        //commente.text = "fffffff";
        //commente.throw_id = 1;
        //commentsBot1.Add(commente);
        //OnBot1MessageSend.Call(commente.text);
        //OnBot1MessageSend.Call("cccccdcdc");
        //OnBot2MessageSend.Call("qqqqqq");
        //OnBot2MessageSend.Call("qqqqqq");

    }
    private void Update()
    {
        //OnBot1MessageSend.Call("cccccdcdc");
        //OnBot2MessageSend.Call("qqqqqq");
    }
    void DisplayBotMessage()
    {
        foreach (var comment in commentsBot1)
        {
            if (comment.throw_id == RSO_BallThrowCount.Value)
            {
                OnBot1MessageSend.Call(comment.text);
            }
        }

        foreach (var comment in commentsBot2)
        {
            if (comment.throw_id == RSO_BallThrowCount.Value)
            {
                OnBot2MessageSend.Call(comment.text);
            }
        }

       
    }

    private void OnEnable()
    {
        send.action += DisplayBotMessage;
    }

    private void OnDisable()
    {
        send.action -= DisplayBotMessage;
    }
}