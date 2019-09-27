using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAMoverPontos : MonoBehaviour {

    NavMeshAgent agent;

    enum TEst {
        idle,
        mover,
    }

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    void IA () {

    }

}
