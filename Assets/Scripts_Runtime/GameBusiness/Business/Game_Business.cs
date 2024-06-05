using System;
using UnityEngine;

public static class Game_Business {

    public static void New_Game(GameContext ctx) {

        RoleEntity role = RoleDomain.Spawn(ctx);
        role.id = ctx.gameEntity.roleRecordID;
        GunEntity gun = GunDomain.Spawn(ctx,role.gunPos);
        
    }

    public static void Load_Game(GameContext ctx) {

    }

    public static void Unload_Game(GameContext ctx) {

    }

    public static void Tick(GameContext ctx, float dt) {
        PreTick(ctx, dt);


        ref float restFixTime = ref ctx.gameEntity.restFixTime;

        restFixTime += dt;
        const float FIX_INTERVAL = 0.02f;

        if (restFixTime <= FIX_INTERVAL) {
            LogicFix(ctx, FIX_INTERVAL);
            restFixTime = 0;
        } else {
            while (restFixTime >= FIX_INTERVAL) {
                LogicFix(ctx, FIX_INTERVAL);
                restFixTime -= FIX_INTERVAL;
            }
        }



        LateTick(ctx, dt);
    }


    static void PreTick(GameContext ctx, float dt) {

    }


    static void LogicFix(GameContext ctx, float dt) {
        ctx.roleRespository.Foreach((RoleEntity role) => {
            if (role.id == ctx.gameEntity.roleRecordID) {

                RoleDomain.Move(role, ctx.moduleInput.moveAxis, 5, dt);
                RoleDomain.Rotate(ctx.mainCamera, role, ctx.moduleInput.mousePos, dt);

            }
        });


    }

    static void LateTick(GameContext ctx, float dt) {

    }

}