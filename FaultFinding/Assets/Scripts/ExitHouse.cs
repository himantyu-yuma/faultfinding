using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitHouse : MonoBehaviour
{
    private GameMaster master;
    private MessageManager messageManager;

    [SerializeField]
    private Transform outsidePos = default;

    // Start is called before the first frame update
    void Start()
    {
        master = GameObject.FindGameObjectWithTag("Master").GetComponent<GameMaster>();

        messageManager = GameObject.FindGameObjectWithTag("MessageManager").GetComponent<MessageManager>();

    }

    private void OnTriggerStay(Collider other)
    {
       if (other.tag == "Player" && master.IsGetKey == false && Input.GetMouseButtonDown(0))
        {
            if(master.isCheckDoor == false)
            {
                master.isCheckDoor = true;
            }
            messageManager.ShowText(1);
        } else if (other.tag == "Player" && master.IsGetKey == true && Input.GetMouseButtonDown(0) && !master.isOpenExitDoor)
        {
            messageManager.ShowText(5);
            master.isOpenExitDoor = true;
        }
        if (other.tag == "Player" && master.isOpenExitDoor && Input.GetMouseButtonDown(0) && !master.IsNowMessage)
        {
            other.transform.position = outsidePos.position;
        }
    }
}
