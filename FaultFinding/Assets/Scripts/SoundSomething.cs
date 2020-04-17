using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSomething : MonoBehaviour
{
    private GameMaster master;
    private AudioSource source;
    [SerializeField]
    private AudioClip noise = default;

    private MessageManager messageManager;

    private void Start()
    {
        master = GameObject.FindGameObjectWithTag("Master").GetComponent<GameMaster>();
        source = this.GetComponent<AudioSource>();

        messageManager = GameObject.FindGameObjectWithTag("MessageManager").GetComponent<MessageManager>();
    }

    private void Update()
    {
        if(master.isCheckDoor == true && master.IsNowMessage == false)
        {
            SoundNoise();
            this.enabled = false;
        }
    }
    public void SoundNoise()
    {
        source.PlayOneShot(noise);
        StartCoroutine("Text");
    }

    private IEnumerator Text()
    {
        yield return new WaitForSeconds(1);
        messageManager.ShowText(2);
        master.DoorManager.OpenFirst();
    }
}
