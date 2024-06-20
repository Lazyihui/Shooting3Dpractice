using System;
using System.Collections.Generic;
using UnityEngine;

public static class GameDomaim {


    public static void Init(GameContext ctx) {

        MstPosInit(ctx);

    }

    
    
    static void MstPosInit(GameContext ctx) {
        List<Vector2Int> mstPos = new List<Vector2Int> {
            new Vector2Int (-1,-3),
            new Vector2Int (2,-4),
            new Vector2Int (4,3),
            new Vector2Int (1,3),
            new Vector2Int (-3,2),
            new Vector2Int (-4,-1),
            new Vector2Int (3,-1),
            new Vector2Int (3,-3),
        };

        ctx.gameEntity.mstPos = mstPos;
    }



}