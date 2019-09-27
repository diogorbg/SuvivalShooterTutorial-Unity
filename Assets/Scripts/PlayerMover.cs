using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMover : MonoBehaviour {

    public float vel = 5f;
    public Transform camRef;

    NavMeshAgent agent;
    Animator anim;

    private void Awake() {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update() {
        Vector3 dir = Vector3.zero;
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");

        if (dir.sqrMagnitude > 0.01f)
            dir.Normalize();

        anim.SetFloat("vel", dir.magnitude);
        dir *= vel;
        agent.velocity = camRef.forward * dir.z + camRef.right * dir.x;
    }

}
