using System;
using System.Collections.Generic;
using UnityEngine;

public static class GameDomaim {


    public static void Init(GameContext ctx) {

        ctx.gameEntity.Ctor();
        ctx.gameEntity.mstSpawnTimer = 0;

        MstPosInit(ctx);

    }

    
    
    static void MstPosInit(GameContext ctx) {
        List<Vector3> mstPos = new List<Vector3> {
            new Vector3 (-1.5f,1,-3.5f),
            new Vector3 (2.5f,1,-4.5f),
            new Vector3 (4.5f,1,4.5f),
            new Vector3 (1.5f,1,4.5f),
            new Vector3 (-3.5f,1,2.5f),
            new Vector3 (-4.5f,1,-1.5f),
            new Vector3 (4.5f,1,-1.5f),
            new Vector3 (3.5f,1,-3.5f),
        };

        ctx.gameEntity.mstPos = mstPos;

        ctx.gameEntity.mstPosIndex = new int[mstPos.Count];

        for (int i = 1; i < mstPos.Count; i++) {
            ctx.gameEntity.mstPosIndex[i] = i;
        }


    }



}