using System;
using UnityEngine;


public static class BulletDomain {
    public static BulletEntity Spawn(GameContext ctx, Transform pos) {
        bool has = ctx.assetsContext.TryGetEntity("Bullet_Entity", out GameObject prefab);
        if (!has) {
            Debug.LogError("Bullet_Entity not found");
            return null;
        }

        BulletEntity bullet = GameObject.Instantiate(prefab,pos).GetComponent<BulletEntity>();
        bullet.Ctor();
        bullet.id = ctx.gameEntity.bulletRecordID++;
        ctx.bulletRespository.Add(bullet);
        return bullet;
    }
}