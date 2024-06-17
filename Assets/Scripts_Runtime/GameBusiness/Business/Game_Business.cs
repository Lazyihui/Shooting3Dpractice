using System;
using System.Collections.Generic;
using UnityEngine;

public static class Game_Business {

    public static void New_Game(GameContext ctx) {

        RoleEntity role = RoleDomain.Spawn(ctx);
        role.id = ctx.gameEntity.roleRecordID;

        GunEntity gun = GunDomain.Spawn(ctx, role.gunPos);
        gun.id = ctx.gameEntity.gunRecordID;

        MstEntity mst = MstDomain.Spawn(ctx);
        mst.id = ctx.gameEntity.mstRecordID;

        HinderEntity hinder = HinderDomain.Spawn(ctx, new Vector3(1, 0, 1));
        ctx.hinderList.Add(new Vector2Int(1, 1));


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

        int roleLen = ctx.roleRespository.TakeAll(out RoleEntity[] roles);
        for (int i = 0; i < roleLen; i++) {
            RoleEntity role = roles[i];
            if (role.id == ctx.gameEntity.roleRecordID) {
                RoleDomain.Move(role, ctx.moduleInput.moveAxis, 5);
                RoleDomain.Rotate(ctx.mainCamera, role, ctx.moduleInput.mousePos, dt);

            }
        }

        int gunLen = ctx.gunRespository.TakeAll(out GunEntity[] guns);
        for (int i = 0; i < gunLen; i++) {
            GunEntity gun = guns[i];
            if (gun.id == ctx.gameEntity.gunRecordID) {
                GunDomain.GunShootBlt(ctx, gun);
            }
        }



        int mstLen = ctx.mstRespository.TakeAll(out MstEntity[] msts);
        {
                RoleEntity role = ctx.roleRespository.TryGet(ctx.gameEntity.roleRecordID, out RoleEntity roleEntity) ? roleEntity : null;
            for (int i = 0; i < mstLen; i++) {
                MstEntity mst = msts[i];
                MstDomain.FindPath(ctx, mst, role, ctx.hinderList);
                MstDomain.MoveByPath(mst, role, dt);
            }
        }


        int bltLen = ctx.bulletRespository.TakeAll(out BulletEntity[] bullets);
        for (int i = 0; i < bltLen; i++) {
            BulletEntity bullet = bullets[i];

            BulletDomain.Move(bullet, dt);
            BulletDomain.BltLapMst(ctx, bullet);

        }



    }

    static void LateTick(GameContext ctx, float dt) {

    }

}