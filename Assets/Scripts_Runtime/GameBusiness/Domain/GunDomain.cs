using System;
using UnityEngine;

public static class GunDomain {
    public static GunEntity Spawn(GameContext ctx,Vector3 pos){
        bool has = ctx.assetsContext.TryGetEntity("Gun_Entity", out GameObject prefab);
        if (!has) {
            Debug.LogError("Gun_Entity not found");
            return null;
        }

        GunEntity gun = GameObject.Instantiate(prefab).GetComponent<GunEntity>();

        gun.transform.position = pos;
        gun.Ctor();
        gun.id = ctx.gameEntity.gunRecordID++;
        ctx.gunRespository.Add(gun);
        return gun;
    }
}