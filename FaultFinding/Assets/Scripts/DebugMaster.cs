using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMaster : MonoBehaviour
{
    private GameMaster master;
    [SerializeField]
    public bool isDebug = false;

    // Start is called before the first frame update
    void Start()
    {
        master = GameObject.FindGameObjectWithTag("Master").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!master.IsDebugMode)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.B) && isDebug)
        {
            isDebug = false;
            master.MoveAll();
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (Input.GetKeyDown(KeyCode.B) && !isDebug)
        {
            Cursor.lockState = CursorLockMode.None;

            isDebug = true;
            master.StopAll();
        }
    }
}
