using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAPerseguir : StateMachineBehaviour {

    IAInimigo inim;
    NavMeshAgent agente;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        inim = animator.GetComponentInParent<IAInimigo>();
        agente = animator.GetComponentInParent<NavMeshAgent>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        if (proximoPlayer()) {
            agente.enabled = false;
            animator.SetBool("atacar", true);
        }
        else {
            agente.enabled = true;
            agente.SetDestination( Player.pos );
            animator.SetBool("atacar", false);
        }

    }

    bool proximoPlayer() {
        Vector3 dist = inim.transform.position - Player.pos;
        return dist.sqrMagnitude < inim.distAtacar * inim.distAtacar;
    }

}
