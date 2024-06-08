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
        Vector3 pos = transform.position;
        pos += transform.forward * speed * dt;
        transform.position = pos;

    }   

    public void TearDown() { 
        // GameObject.Destroy(gameObject);
          this.gameObject.SetActive(false);

    }
}