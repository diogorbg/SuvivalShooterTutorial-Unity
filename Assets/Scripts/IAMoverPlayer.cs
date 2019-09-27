using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAMoverPlayer : MonoBehaviour {

    public int dano = 1;
    public float distAtaque = 1.2f;
    public float tempoAtaque = 1f;

    NavMeshAgent agent;
    Animator anim;
    bool bAtacando = false;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        IA();
    }

    private void Update() {
        anim.SetFloat("vel", agent.velocity.magnitude);
        if (podeAtacar()) {
            bAtacando = true;
            anim.CrossFade("Attack", 0.1f);
        }
    }

    void IA () {
        Invoke("IA", 1f + Random.value);
        agent.SetDestination(Player.pos);
    }

    bool podeAtacar () {
        Vector3 dist = transform.position - Player.pos;
        if (bAtacando==false && dist.sqrMagnitude < distAtaque*distAtaque) {
            return true;
        }
        return false;
    }

    public void attack() {
        Vector3 dist = transform.position - Player.pos;
        if (dist.sqrMagnitude < distAtaque * distAtaque) {
            Player.addHit(dano);
        }
        Invoke("resetAttack", tempoAtaque);
    }

    void resetAttack() {
        bAtacando = false;
    }

}
