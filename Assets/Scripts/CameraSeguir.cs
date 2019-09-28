using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSeguir : MonoBehaviour {

    public Transform alvo;
    public float z_offset;

    private void Start() {
        transform.parent = null;
    }

    [ContextMenu("Seguir")]
    private void LateUpdate() {
        transform.position = alvo.position + transform.forward * z_offset;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos() {
        Vector3 p2 = transform.GetChild(0).position;
        Vector3 p3 = transform.GetChild(0).GetChild(0).position;

        if (alvo)
            Gizmos.DrawLine(alvo.position, transform.position);
        Gizmos.DrawLine(transform.position, p2);
        Gizmos.DrawLine(p2, p3);
    }
#endif

}
