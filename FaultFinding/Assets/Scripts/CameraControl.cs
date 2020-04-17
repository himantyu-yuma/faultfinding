using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    private Transform cameraTrans;
    private Transform parentTrans;

    [SerializeField]
    private float maxAngle = 270;
    [SerializeField]
    private float minAngle = 90;

    private Vector3 localAngle;

    [SerializeField]
    private float speed = 1;

    private float inputVertical;
    private float inputHorizontal;

    // -----debug------
    [SerializeField]
    private bool isMouseLock = true;
    // ----------------

    // Start is called before the first frame update
    void Start()
    {

        cameraTrans = this.transform;
        parentTrans = this.transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        // -----debug-----
        if (isMouseLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            isMouseLock = !isMouseLock;
        }

        // --------------

        inputVertical = Input.GetAxis("Mouse X");
        inputHorizontal = Input.GetAxis("Mouse Y");


        parentTrans.Rotate(Vector3.up * inputVertical * speed);
        cameraTrans.Rotate(Vector3.right * -inputHorizontal * speed);

        localAngle = cameraTrans.localEulerAngles;

        if(cameraTrans.localEulerAngles.x <= maxAngle && cameraTrans.localEulerAngles.x >= 180)
        {
            localAngle.x = maxAngle + 1;
        }
        if(cameraTrans.localEulerAngles.x >= minAngle && cameraTrans.localEulerAngles.x <= 180)
        {
            localAngle.x = minAngle - 1;
        }

        cameraTrans.localEulerAngles = localAngle;

    }

}
