using System;
using UnityEngine;


public class RoleEntity : MonoBehaviour {

    [SerializeField] Rigidbody rb;

    [SerializeField] public Transform gunPos;

    public int id;


    public RoleEntity() { }
    public void Ctor() { }

    public void Move(Vector2 moveAxis, float speed, float dt) {

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

    // public void Rotate(Vector3 rotateAxis, float dt) {
    //     if (rotateAxis == Vector3.zero) {
    //         return;
    //     }
    //     Quaternion rot = Quaternion.LookRotation(rotateAxis);
    //     // Debug.Log("rot:" + rot);
    //     // 只需要y轴旋转
    //     transform.rotation = Quaternion.Slerp(transform.rotation, rot, dt);

    // }
}