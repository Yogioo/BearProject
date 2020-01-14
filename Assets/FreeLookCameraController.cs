using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeLookCameraController : MonoSingleton<FreeLookCameraController> {
    InputController input;
    private Transform x;
    private Transform y;
    public Camera mainCam { get; private set; }
    public BearController bearController;
    void Awake () {
        input = InputController.Instance;
        x = transform;
        y = x.Find ("YHandler");
        mainCam = y.Find ("MainCam").GetComponent<Camera> ();
        bearController = BearController.Instance;
    }

    void FixedUpdate () {
        RotateCamera();
    }

    void RotateCamera () {
        if (input.mouseX != 0) {
            x.Rotate (new Vector3 (0, 1, 0) * input.mouseX);
        }

        if (input.mouseY != 0) {
            y.Rotate (new Vector3 (1, 0, 0) * -input.mouseY);
            ClimpRotationAngle (y, 60, 330);
        }
        CameraTrigger();
    }

    // 限定摄像机旋转角度
    void ClimpRotationAngle (Transform trans, float min, float max) {
        if (trans.localEulerAngles.x > 60 && trans.localEulerAngles.x < 330) { // 60~0  360~330
            if (input.mouseY > 0) {
                trans.localEulerAngles = new Vector3 (330, trans.localEulerAngles.y, trans.localEulerAngles.z);
            } else {
                trans.localEulerAngles = new Vector3 (60, trans.localEulerAngles.y, trans.localEulerAngles.z);
            }
        }
    }

    void CameraTrigger(){
        Ray ray = mainCam.ScreenPointToRay(bearController.transform.position);
        if(Physics.Raycast(ray,out RaycastHit hit,1000f)){
            Debug.Log(hit.transform.name);
        }
    }
}