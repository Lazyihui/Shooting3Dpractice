using System;
using UnityEngine;


public class MstEntity : MonoBehaviour {
    public int id;

    [SerializeField] Rigidbody rb;

    public float moveSpeed;

    public Vector2Int[] path;

    public Vector2Int logicPos;

    public int pathIndex;
    public int pathCount;

    // 碰撞返回的信息

    public bool isCollide;

    public float collideTime;

    public Action<MstEntity, Collision> OnCollisionEnterHandle;

    public MstEntity() {
    }
    public void Ctor() {
    }

    public void SetPos(Vector3 pos) {
        transform.position = pos;
        logicPos = new Vector2Int((int)pos.x, (int)pos.z);
    }


    public void Move(Vector3 direction, float dt) {

        // 按照格子移动
        // Vector3 pos = transform.position;
        // pos += direction * moveSpeed * dt;
        // transform.position = pos;

        rb.velocity = direction * moveSpeed;

    }

    public void RevervseMove(Vector3 direction) {
        rb.velocity = direction * 5f;

    }

    public void TearDown() {
        // GameObject.Destroy(gameObject);
        this.gameObject.SetActive(false);
    }

    public void OnCollisionEnter(Collision other) {
        OnCollisionEnterHandle.Invoke(this, other);
    }

}