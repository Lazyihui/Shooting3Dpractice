using System;
using UnityEngine;


public class MstEntity : MonoBehaviour {
    public int id;

    public MstEntity() {
    }
    public void Ctor() {
    }

    public void Move(Vector3 direction) {
        transform.position += direction;
    }
}