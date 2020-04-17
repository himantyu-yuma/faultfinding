using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    private GameObject[] FirstOpenDoor;
    private GameObject[] SecondOpenDoor;

    // Start is called before the first frame update
    void Start()
    {
        FirstOpenDoor = GameObject.FindGameObjectsWithTag("FirstDoor");
        SecondOpenDoor = GameObject.FindGameObjectsWithTag("SecondDoor");
    }

    public void OpenFirst()
    {
        for (int i = 0; i < FirstOpenDoor.Length; i++)
        {
            FirstOpenDoor[i].GetComponent<OpenDoor>().isOpen = true;
        }
    }

    public void OpenSecond()
    {
        for (int i = 0; i < SecondOpenDoor.Length; i++)
        {
            SecondOpenDoor[i].GetComponent<OpenDoor>().isOpen = true;
        }
    }

}
