using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    private GameMaster master;
    private MessageManager messageManager;

    [SerializeField]
    private GoToNextStage next = default;

    [SerializeField]
    private GameObject blackImage = default;

    // Start is called before the first frame update
    void Start()
    {
        master = GameObject.FindGameObjectWithTag("Master").GetComponent<GameMaster>();
        messageManager = GameObject.FindGameObjectWithTag("MessageManager").GetComponent<MessageManager>();
        blackImage.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            messageManager.ShowText(6);
            blackImage.SetActive(true);
            master.IsEnd = true;

            next.enabled = true;
        }
    }
}
