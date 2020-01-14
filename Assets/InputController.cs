using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoSingleton<InputController> {
    public float vert { get; private set; }
    public float Hori { get; private set; }
    public float mouseX { get; private set; }
    public float mouseY { get; private set; }

    void FixedUpdate () {
        vert = Input.GetAxis ("Vertical");
        Hori = Input.GetAxis ("Horizontal");
        mouseX = Input.GetAxis ("Mouse X");
        mouseY = Input.GetAxis ("Mouse Y");
    }
}