using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextStage : MonoBehaviour
{
    private GameMaster master;
    private MessageManager messageManager;
    private bool isMessageShown = false;

    private int downCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        master = GameObject.FindGameObjectWithTag("Master").GetComponent<GameMaster>();
        messageManager = GameObject.FindGameObjectWithTag("MessageManager").GetComponent<MessageManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (master.IsEnd && !master.IsNowMessage && Input.anyKeyDown && !isMessageShown)
        {
            if(downCount <= 2)
            {
                downCount++;
                return;
            }else if (master.IsDebugMode)
            {
                Destroy(this.gameObject);
                return;
            }
            messageManager.ShowText(9);
            isMessageShown = true;
        }else if (isMessageShown && !master.IsNowMessage)
        {
            master.IsDebugMode = true;
            master.IsEnd = false;
            Destroy(this.gameObject);
            SceneManager.LoadScene(2);
        }
    }
    
}
