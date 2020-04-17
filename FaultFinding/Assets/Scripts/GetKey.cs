using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKey : MonoBehaviour, IBugable
{
    private GameMaster master;
    private DebugMaster debugMaster;
    [SerializeField]
    private MessageManager messageManager;
    private GameObject key;

    private static bool isBugFixed = false;
   
    // Start is called before the first frame update
    void Start()
    {
        master = GameObject.FindGameObjectWithTag("Master").GetComponent<GameMaster>();
        debugMaster = GameObject.FindGameObjectWithTag("Master").GetComponent<DebugMaster>();
        messageManager = GameObject.FindGameObjectWithTag("MessageManager").GetComponent<MessageManager>();
        key = this.gameObject;
    }

    private void OnTriggerStay(Collider other)
    {
        if (debugMaster.isDebug)
        {
            return;
        }
        if(other.tag != "Player")
        {
            return;
        }else if(other.tag == "Player")
        {
            if (Input.GetMouseButtonDown(0))
            {
                master.IsGetKey = true;
                messageManager.ShowText(4);
                if (isBugFixed)
                {
                    key.SetActive(false);
                }
            }
        }
    }

    public void BugFix()
    {
        isBugFixed = true;
        if (master.IsGetKey)
        {
            key.SetActive(false);
        }
    }
}
