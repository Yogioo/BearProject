using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearController : MonoSingleton<BearController> {
    private InputController input;
    private FreeLookCameraController camControl;
    private Animator anim;
    public float rotateSpeed = 5;

    private bool isLockToRotate;
    private bool isRun;

    void Awake () {
        input = InputController.Instance;
        camControl = FreeLookCameraController.Instance;
        anim = GetComponent<Animator> ();
    }

    void Start () {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate () {
        MoveAnim ();
        Rotate ();
    }

    void MoveAnim () {
        anim.SetFloat ("Horizontal", input.Hori);
        anim.SetFloat ("Vertical", input.vert);
        RunAnim ();
    }

    void RunAnim () {
        if (Input.GetKey (KeyCode.LeftShift) || Input.GetKeyDown (KeyCode.RightShift)) {
            isRun = true;
        } else {
            isRun = false;
        }
        anim.SetBool ("Run", isRun);
    }

    void Rotate () {
        LockRotate ();
        LookAtForward ();
    }

    void LockRotate () {
        if (Input.GetMouseButton (1)) {
            isLockToRotate = true;
        } else {
            isLockToRotate = false;
        }
    }

    void LookAtForward () {
        if (isLockToRotate)
            return;
        Vector3 targetDir = Vector3.Lerp (transform.forward, camControl.mainCam.transform.forward, Time.deltaTime * rotateSpeed);
        targetDir.y = 0;
        transform.forward = targetDir;

    }

    void FootR () {

    }

    void FootL () {

    }

}