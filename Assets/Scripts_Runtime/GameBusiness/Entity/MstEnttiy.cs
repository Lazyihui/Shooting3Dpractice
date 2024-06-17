using System;
using UnityEngine;


public class MstEntity : MonoBehaviour {
    public int id;

    public float moveSpeed;

    public RectCell cell;

    public Vector2Int[] path;

    public int pathIndex;
    public int pathCount;

    public bool isNear;
    public MstEntity() {
    }
    public void Ctor() {
    }

    public void Move(Vector3 direction, float dt) {

        // 按照格子移动
        Vector3 pos = transform.position;
        pos += direction * moveSpeed * dt;
        transform.position = pos;

    }

    public void TearDown() {
        // GameObject.Destroy(gameObject);
          this.gameObject.SetActive(false);
    }

}