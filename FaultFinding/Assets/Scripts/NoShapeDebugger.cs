using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoShapeDebugger : MonoBehaviour
{
    private GameMaster master;

    private void Start()
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
        if (master.IsDebugMode && Input.GetKeyDown(KeyCode.B))
        {
            this.GetComponent<IBugable>().BugFix();
        }
    }
}
