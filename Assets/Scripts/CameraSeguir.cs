using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSeguir : MonoBehaviour {

    public Transform alvo;
    public float z_offset;

    private void Start() {
        transform.parent = null;
    }

    private void LateUpdate() {
        transform.position = alvo.position + transform.forward * z_offset;
    }

}
