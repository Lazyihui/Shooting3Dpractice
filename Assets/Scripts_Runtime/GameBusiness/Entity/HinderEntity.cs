using System;
using System.Collections.Generic;
using UnityEngine;

public class HinderEntity : MonoBehaviour {

    public int id;

    public HinderEntity() { }

    public void Ctor() { }

    public void SetPos(Vector3 pos) {
        transform.position = pos;
    }

}