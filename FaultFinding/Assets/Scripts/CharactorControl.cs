using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorControl : MonoBehaviour
{
    private Transform charactorTrans;
    [SerializeField]
    private float speed = 1;

    private Rigidbody charactorRigid;


    private void Start()
    {
        charactorTrans = this.transform;
        charactorRigid = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        charactorRigid.angularVelocity = Vector3.zero;
        
    }

    public void Move(float vertical, float horizontal)
    {
        charactorTrans.Translate(Vector3.forward * vertical * speed);
        charactorTrans.Translate(Vector3.right * horizontal * speed);
    }
}
