using System;
using UnityEngine;

public static class GunDomain {
    public static GunEntity Spawn(GameContext ctx, Transform pos) {
        bool has = ctx.assetsContext.TryGetEntity("Gun_Entity", out GameObject prefab);
        if (!has) {
            Debug.LogError("Gun_Entity not found");
            return null;
        }

        GunEntity gun = GameObject.Instantiate(prefab, pos.position, pos.rotation).GetComponent<GunEntity>();
        gun.transform.parent = pos;

        gun.Ctor(3, 1,0);
        gun.id = ctx.gameEntity.gunRecordID++;
        ctx.gunRespository.Add(gun);
        return gun;
    }

    public static void GunShootBlt(GameContext ctx, GunEntity gun) {

        if (Input.GetMouseButtonDown(0)) {
 

            //  if (Time.time > gun.nextShotTime) {
 
            //     gun.nextShotTime = Time.time + gun.msBetweenShots / 1000;
                BulletEntity blt = BulletDomain.Spawn(ctx, gun.bulletPos);
                blt.SetSpeed(gun.muzzleVelocity);

                blt.id = ctx.gameEntity.bulletRecordID++;
                ctx.bulletRespository.Add(blt);
            // }
        }
    }
}