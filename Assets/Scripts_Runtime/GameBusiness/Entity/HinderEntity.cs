using System;
using System.Collections.Generic;
using UnityEngine;

public class HinderEntity : MonoBehaviour {

    public int id;

    public Vector2Int logicPos;

    public HinderEntity() { }

    public void Ctor() { }

    public void SetPos(Vector3 pos) {
        transform.position = pos;
        logicPos = new Vector2Int((int)pos.x, (int)pos.z);
    }

}