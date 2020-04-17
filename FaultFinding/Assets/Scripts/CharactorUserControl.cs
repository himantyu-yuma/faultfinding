using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharactorControl))]
public class CharactorUserControl : MonoBehaviour
{
    private CharactorControl contorol;

    private float inputVertical;
    private float inputHorizontal;

    // Start is called before the first frame update
    void Start()
    {
        contorol = this.GetComponent<CharactorControl>();
    }

    // Update is called once per frame
    void Update()
    {
        inputVertical = Input.GetAxis("Vertical");
        inputHorizontal = Input.GetAxis("Horizontal");
        contorol.Move(inputVertical, inputHorizontal);
    }
}
