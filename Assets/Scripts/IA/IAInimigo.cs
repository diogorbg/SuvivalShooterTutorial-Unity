using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAInimigo : MonoBehaviour {

    public Transform[] pontos;
    public float distPerseguir = 10f;
    public float distAtacar = 2f;

    NavMeshAgent agente;

    void Start() {
        agente = GetComponent<NavMeshAgent>();
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, distPerseguir);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distAtacar);
    }

}
