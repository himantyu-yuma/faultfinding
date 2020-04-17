using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private GameMaster master;
    private MessageManager messageManager;

    private Animator animator;

    public bool isOpen = false;

    private Vector3 thisForward;
    private Vector3 playerForward;
    private Vector3 enemyForward;

    private float innerProduct;

    private bool isUpset = false;

    // Start is called before the first frame update
    void Start()
    {
        master = GameObject.FindGameObjectWithTag("Master").GetComponent<GameMaster>();
        messageManager = GameObject.FindGameObjectWithTag("MessageManager").GetComponent<MessageManager>();

        animator = this.GetComponent<Animator>();
        thisForward = this.transform.forward;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            playerForward = other.transform.forward;

            innerProduct = Vector3.Dot(thisForward, playerForward);

            if (Input.GetMouseButtonDown(0))
            {
                if(master.isCheckDoor == false)
                {
                    messageManager.ShowText(8);
                    return;
                }
                if(isOpen == false)
                {
                    messageManager.ShowText(7);
                    return;
                }

                if(innerProduct > 0 && innerProduct <= 1)
                {
                    animator.SetBool("isOpenUpset", true);
                    isUpset = true;
                }else if(innerProduct < 0 && innerProduct >= -1)
                {
                    animator.SetBool("isOpen", true);
                    isUpset = false;
                }
            }
        }
        else if(other.tag == "Enemy")
        {
            enemyForward = other.transform.forward;
            innerProduct = Vector3.Dot(thisForward, enemyForward);

            if (master.isCheckDoor == false)
            {
                return;
            }
            if (isOpen == false)
            {
                return;
            }

            if (innerProduct > 0 && innerProduct <= 1)
            {
                animator.SetBool("isOpenUpset", true);
                isUpset = true;
            }
            else if (innerProduct < 0 && innerProduct >= -1)
            {
                animator.SetBool("isOpen", true);
                isUpset = false;
            }
        }
        else
        {
            return;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player" || other.tag == "Enemy")
        {
            if (isUpset)
            {
                animator.SetBool("isOpenUpset", false);
            }
            else
            {
                animator.SetBool("isOpen", false);
            }
        }
        else
        {
            return;
        }
    }
}
