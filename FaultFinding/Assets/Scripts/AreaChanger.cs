using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaChanger : MonoBehaviour
{
    private GameMaster master;

    [SerializeField]
    private int areaID = 0;

    public int AreaID
    {
        get { return this.areaID; }
    }
    // Start is called before the first frame update
    void Start()
    {
        master = GameObject.FindGameObjectWithTag("Master").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (master.isChase)
        {
            if(other.tag == "Player")
            {
                if(master.CurrentAreaID != this.areaID && master.FormerAreaID != this.areaID)
                {
                    master.CurrentAreaID = this.areaID;
                    master.ChangeArea();
                }
                else
                {
                    return;
                }
            }
        }
    }
}
