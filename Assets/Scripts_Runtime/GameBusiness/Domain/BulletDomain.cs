using System;
using UnityEngine;


public static class BulletDomain {
    public static BulletEntity Spawn(GameContext ctx, Transform pos) {
        bool has = ctx.assetsContext.TryGetEntity("Bullet_Entity", out GameObject prefab);
        if (!has) {
            Debug.LogError("Bullet_Entity not found");
            return null;
        }

        BulletEntity bullet = GameObject.Instantiate(prefab, pos.position, pos.rotation).GetComponent<BulletEntity>();
        bullet.Ctor();
        bullet.id = ctx.gameEntity.bulletRecordID++;
        ctx.bulletRespository.Add(bullet);

        return bullet;
    }

    public static void Move(BulletEntity bullet, float dt) {
        bullet.Move(dt);
    }

    public static void Unspawn(GameContext ctx, BulletEntity bullet) {
        ctx.bulletRespository.Remove(bullet);
        bullet.TearDown();
    }

    // public static void BltLapMst(GameContext ctx, BulletEntity blt) {
    //     ctx.mstRespository.Foreach((MstEntity mst) => {

    //         float dirSqr = Vector2.SqrMagnitude(mst.transform.position - blt.transform.position);
    //         if (dirSqr < 0.1f) {
    //             BulletDomain.Unspawn(ctx, blt);
    //             MstDomain.Unpawn(ctx, mst);
    //         }else{
    //             Debug.Log(dirSqr);
    //         }

    //     });
    // }
    public static void BltLapMst(GameContext ctx, BulletEntity blt) {
        int count = ctx.mstRespository.TakeAll(out MstEntity[] msts);
        for (int i = 0; i < count; i++) {
            MstEntity mst = msts[i];

            float dirSqr = Vector2.SqrMagnitude(mst.transform.position - blt.transform.position);
            if (dirSqr < 0.1f) {
                BulletDomain.Unspawn(ctx, blt);
                MstDomain.Unpawn(ctx, mst);
            } else {
                Debug.Log(dirSqr);
            }
        }
    }
}