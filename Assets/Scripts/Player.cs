using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    static Player singleton;

    public int hp = 100;

    public static Vector3 pos {
        get { return singleton.transform.position; }
    }

    public static void addHit (int dano) {
        singleton.hp -= dano;
        print("Player HP: " + singleton.hp);
    }

    private void Awake() {
        singleton = this;
    }

}
