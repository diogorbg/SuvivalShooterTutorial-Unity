using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Esta é uma IA feita apenas para seguir o jogador.
// Ela irá chamar a animação de Attack assim que chegar perto do jogador.
// A função IA() é responsável pelas decisões do inimigo... ela é feita com um delay de 1 a 2 segundos para parecer um comportamento mais natural.
// Não foi projetada para mais de um jogador em cena

public class IAMoverPlayer : MonoBehaviour {

    public int dano = 1;            // Dano causado pelo inimigo
    public float distAtaque = 1.2f; // Distancia para iniciar o ataque
    public float tempoAtaque = 1f;  // tempo para o próximo ataque

    NavMeshAgent agent; // Um agente permite o uso da malha de navegação NavMesh
    Animator anim;      // Controla as animações

    bool bAtacando = false; // Uma simples flag para permitir ou não o ataque

    // Vamos pegar as referências dos componentes que iremos utilizar e rodar a função IA()
    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        IA();
    }

    private void Update() {
        // A forma mais simples e funcional de explicar para um Animator se o personagem deve andar ou ficar parado é informando a velocidade.
        anim.SetFloat("vel", agent.velocity.magnitude);

        // O teste de ataque pode ser feito no update para que o inimigo não exite em atacar assim que tiver a chance
        // Mas ele apenas chama a animação de ataque... a animação irá conter o evento para o ataque no momento exato.
        if (podeAtacar) {
            bAtacando = true;
            anim.CrossFade("Attack", 0.1f);
        }
    }

    // A intenção da função IA() é tomar decisões de tempos em tempos... não gasta muito processamento e fica mais natural.
    // Além disso, se a IA possui pausas nas decisões o jogador terá pequenas janelas de tempo de vantagem... o que não é bem interessante.
    void IA () {
        Invoke("IA", 1f + Random.value);
        agent.SetDestination(Player.pos);
    }

    // Programado como um atributo, 'podeAtacar' permite comparar a distância entre inimigo e player.
    // Note que foi usado a atributo 'sqrMagnitude'... que é ideal para comparar distancias sem fazer uso raiz quadrada na fórmula
    // Veja mais em: https://docs.unity3d.com/ScriptReference/Vector3-sqrMagnitude.html
    bool podeAtacar {
        get {
            Vector3 dist = transform.position - Player.pos;
            if (bAtacando == false && dist.sqrMagnitude < distAtaque * distAtaque) {
                return true;
            }
            return false;
        }
    }

    // No momento do ataque é feito um novo teste... e aí sim é causado dano no jogador
    // Note que não funciona para mais de um jogador... pois só testamos com um jogador.
    // Esta função é chamada por um evento disparado pela animação. A classe IAMover_Anim é quem provavelmente irá chamar essa função.
    public void attack() {
        Vector3 dist = transform.position - Player.pos;
        if (dist.sqrMagnitude < distAtaque * distAtaque) {
            Player.addHit(dano);
        }
        Invoke("resetAttack", tempoAtaque);
    }

    // Após o ataque é possível fazer um novo, assim que a flag permitir
    void resetAttack() {
        bAtacando = false;
    }

}
