using System;
using UnityEngine;


public class RoleEntity : MonoBehaviour {

    [SerializeField] Rigidbody rb;

    [SerializeField] public Transform gunPos;


    public int id;

    public int pathIndex;


    public RoleEntity() { }
    public void Ctor() { }

    public void SetPos(Vector3 pos) {
        transform.position = pos;
    }

    public void Move(Vector2 moveAxis, float speed) {

        // Vector2 oldVelocity = rb.velocity;
        // oldVelocity = moveAxis * speed;
        // rb.velocity = oldVelocity;

        Vector3 velo = rb.velocity;
        float oldY = velo.y;
        Vector3 moveDir = new Vector3(moveAxis.x, 0, moveAxis.y);
        moveDir.Normalize();
        //  记 veloctity
        velo = moveDir * speed;
        velo.y = oldY;
        rb.velocity = velo;

    }

}