using System;
using UnityEngine;

public class ModuleInput {

    public Vector2 moveAxis;



    public ModuleInput() {
    }


    public void Tick(float dt) {
        Vector2 move = Vector2.zero;

        if (Input.GetKey(KeyCode.W)) {
            move.y = 1;
        }
        if (Input.GetKey(KeyCode.S)) {
            move.y = -1;
        }
        if (Input.GetKey(KeyCode.A)) {
            move.x = -1;
        }
        if (Input.GetKey(KeyCode.D)) {
            move.x = 1;
        }
        this.moveAxis = move;

    }
}