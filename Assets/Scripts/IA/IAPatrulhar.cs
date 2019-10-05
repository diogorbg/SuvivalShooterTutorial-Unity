using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAPatrulhar : StateMachineBehaviour {

    IAInimigo inim;
    Vector3 alvo;
    NavMeshAgent agente;

    const float distProximidade = 0.4f * 0.4f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        inim = animator.GetComponentInParent<IAInimigo>();
        agente = animator.GetComponentInParent<NavMeshAgent>();

        // Não permite repetiro ponto
        do {
            alvo = inim.pontos[Random.Range(0, inim.pontos.Length)].position;
        } while ( proximoAlvo() );

        // Manda mover para o ponto
        agente.SetDestination(alvo);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (animator.IsInTransition(0)==false && proximoAlvo() ) {
            animator.CrossFade("parado", 0.15f);
        }

        if (visaoPlayer())
            animator.SetTrigger("perseguir");
    }

    bool proximoAlvo () {
        Vector3 dist = inim.transform.position - alvo;
        return dist.sqrMagnitude < distProximidade;
    }

    bool visaoPlayer() {
        Vector3 dist = inim.transform.position - Player.pos;
        return dist.sqrMagnitude < inim.distPerseguir * inim.distPerseguir;
    }

}
