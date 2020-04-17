using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBGMManager : MonoBehaviour,IBugable
{
    private GameMaster master;
    private AudioSource source;

    private static bool isBugFixed = false;

    // Start is called before the first frame update
    void Start()
    {
        master = GameObject.FindGameObjectWithTag("Master").GetComponent<GameMaster>();
        source = this.GetComponent<AudioSource>();
    }

    public void StartBGM()
    {
        source.Play();
    }

    public void StopBGM()
    {
        if (!isBugFixed)
        {
            return;
        }
        else
        {
            source.Stop();
        }

    }

    public void BugFix()
    {
        if (!master.isChase && source.isPlaying)
        {
            isBugFixed = true;
            source.Stop();
        }
    }

}
