using System;
using UnityEngine;


public class MstEntity : MonoBehaviour {
    public int id;

    public float moveSpeed;
    public MstEntity() {
    }
    public void Ctor() {
    }

    public void Move(Vector3 direction, float dt) {

        Vector3 pos = transform.position;
        pos += direction * moveSpeed * dt;
        transform.position = pos;
    }

    public void TearDown() {
        // GameObject.Destroy(gameObject);
          this.gameObject.SetActive(false);
    }

}