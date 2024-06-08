using System;
using UnityEngine;

public class BulletEntity : MonoBehaviour {

    public int id;

    public float speed;

    public BulletEntity() {
    }

    public void Ctor() {
    }

    public void SetSpeed(float speed) {
        this.speed = speed;
    }

    public void Move(float dt) {
        transform.Translate(Vector3.forward * speed * dt);
    }

    public void TearDown() { 
        // GameObject.Destroy(gameObject);
    }
}