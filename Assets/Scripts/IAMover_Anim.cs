using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IAMover_Anim : MonoBehaviour {

    public UnityEvent onAttack;

    public void anim_attack() {
        onAttack.Invoke();
    }

}
