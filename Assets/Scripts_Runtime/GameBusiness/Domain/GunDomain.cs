using System;
using UnityEngine;

public static class GunDomain {
    public static GunEntity Spawn(GameContext ctx){
        bool has = ctx.assetsContext.TryGetEntity("Gun_Entity", out GameObject prefab);
        if (!has) {
            Debug.LogError("Gun_Entity not found");
            return null;
        }

        GunEntity gun = GameObject.Instantiate(prefab).GetComponent<GunEntity>();
        Debug.Assert(gun != null, "GunEntity.handTransform is null");
        Debug.Assert(gun.handTransform != null, "GunEntity.handTransform is null");
        Debug.Assert(gun.handTransform != null, "GunEntity.handTransform is null");
        Debug.Assert(gun.handTransform.parent == null, "GunEntity.handTransform.parent is not null");

        gun.transform.SetParent(gun.handTransform, false);
        gun.Ctor();
        gun.id = ctx.gameEntity.gunRecordID++;
        ctx.gunRespository.Add(gun);
        return gun;
    }
}