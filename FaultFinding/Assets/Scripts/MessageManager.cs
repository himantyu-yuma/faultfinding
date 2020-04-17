using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageManager : MonoBehaviour
{
    [SerializeField]
    private GameMaster master;

    [SerializeField]
    private GameObject textFrame = default;
    [SerializeField]
    private GameObject lastTextFrame = default;

    [SerializeField]
    private Message message = default;
    [SerializeField]
    private LastMessage lastMessage = default;
    [SerializeField]
    private MessageList[] messageList = default;

    private void Start()
    {
        master = GameObject.FindGameObjectWithTag("Master").GetComponent<GameMaster>();
        
    }

    public void ShowText(int messageNumber)
    {
        master.StopAll();
        if (messageNumber == 5)
        {
            lastTextFrame.SetActive(true);
            lastMessage.enabled = true;
            lastMessage.MessageList = messageList[5];
            lastMessage.Restart();
        }
        else
        {
            textFrame.SetActive(true);
            message.enabled = true;
            message.MessageList = messageList[messageNumber];
            message.Restart();
        }
    }

}
