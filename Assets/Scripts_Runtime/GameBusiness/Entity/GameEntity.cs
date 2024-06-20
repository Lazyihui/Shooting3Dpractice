using System;
using System.Collections.Generic;
using UnityEngine;

public class GameEntity {

    public float restFixTime;

    public int roleRecordID;

    public int gunRecordID;

    public int bulletRecordID;

    public int mstRecordID;


    public int HinderRecordID;

    public List<Vector2Int> hinderPos;

    public List<Vector2Int> mstPos;

    public float mstSpawnTimer;

    public float mstSpawnInterval;

    public GameEntity() { }
    public void Ctor() { 
        
        mstPos = new List<Vector2Int>(20);

    }


}