using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{
    [SerializeField]
    private GameMaster master;

    private GameObject textFrame;

    public MessageList MessageList = default;
    private string[] messages;
    private int messageNum = 0;
    [SerializeField]
    private Text textBox = default;
    private int messageLength;

    //private bool isMessageEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        master = GameObject.FindGameObjectWithTag("Master").GetComponent<GameMaster>();
        textBox = this.GetComponent<Text>();
        textFrame = this.transform.parent.gameObject;

        Restart();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            messageNum++;
            if(messageNum > messageLength)
            {
                textBox.text = "";
                //isMessageEnd = true;
                this.enabled = false;
                textFrame.SetActive(false);
                master.MoveAll();
                master.IsNowMessage = false;
                return;
            }
            textBox.text = messages[messageNum];
        }
    }

    public void Restart()
    {
        messageNum = 0;
        messages = MessageList.Message;
        textBox.text = messages[0];
        messageLength = messages.Length - 1;
        master.IsNowMessage = true;
    }
}
