
using System;
using UnityEngine;

public static class MstDomain {
    public static MstEntity Spawn(GameContext ctx) {


        bool has = ctx.assetsContext.TryGetEntity("Mst_Entity", out GameObject prefab);
        if (!has) {
            Debug.LogError("Mst_Entity not found");
            return null;
        }

        MstEntity mst = GameObject.Instantiate(prefab).GetComponent<MstEntity>();
        mst.Ctor();
        mst.moveSpeed = 0.2f;
        mst.id = ctx.mstRecordID++;
        ctx.mstRespository.Add(mst);

        return mst;

    }

    public static void Move(MstEntity mst, RoleEntity role, float dt) {
        Vector3 direction = role.transform.position - mst.transform.position;

        direction.Normalize();
        Debug.Log("direction" + direction);
        mst.Move(direction, dt);
    }



}