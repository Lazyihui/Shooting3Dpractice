using System;
using UnityEngine;

public static class HinderDomain {

    public static HinderEntity Spawn(GameContext ctx, Vector3 pos) {

        bool has = ctx.assetsContext.TryGetEntity("Hinder_Entity", out GameObject prefab);
        if (!has) {
            Debug.LogError("Hinder_Entity prefab not found");
            return null;
        }

        GameObject go = GameObject.Instantiate(prefab);
        HinderEntity entity = go.GetComponent<HinderEntity>();

        entity.SetPos(pos);
        entity.Ctor();

        entity.id = ctx.gameEntity.HinderRecordID++;
        ctx.hinderRepository.Add(entity);
        return entity;
    }


}