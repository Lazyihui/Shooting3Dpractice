using System;
using System.Collections.Generic;
using UnityEngine;

public static class GameDomaim {


    public static void Init(GameContext ctx) {

        ctx.gameEntity.Ctor();
        ctx.gameEntity.mstSpawnTimer = 0;
        ctx.gameEntity.mstSpawnInterval = 3;

        MstPosInit(ctx);

    }

    
    
    static void MstPosInit(GameContext ctx) {
        List<Vector3> mstPos = new List<Vector3> {
            new Vector3 (-1.5f,0,-3.5f),
            new Vector3 (2.5f,0,-4.5f),
            new Vector3 (4.5f,0,3.5f),
            new Vector3 (1.5f,0,3.5f),
            new Vector3 (-3.5f,0,2.5f),
            new Vector3 (-4.5f,0,-1.5f),
            new Vector3 (3.5f,0,-1.5f),
            new Vector3 (3.5f,0,-3.5f),
        };

        ctx.gameEntity.mstPos = mstPos;
    }



}