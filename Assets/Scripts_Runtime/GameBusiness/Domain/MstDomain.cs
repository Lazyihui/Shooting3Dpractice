
using System;
using System.Collections.Generic;
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
        mst.cell = null;
        mst.path = new Vector2Int[100];
        mst.pathIndex = 0;
        mst.moveSpeed = 0.2f;
        mst.isNear = false;
        mst.id = ctx.mstRecordID++;
        ctx.mstRespository.Add(mst);

        return mst;

    }


    public static void FindPath(GameContext ctx, MstEntity mst, RoleEntity role, List<Vector2Int> hinders) {
        Vector2Int start = new Vector2Int((int)mst.transform.position.x, (int)mst.transform.position.z);
        Vector2Int end = new Vector2Int((int)role.transform.position.x, (int)role.transform.position.z);

        int res;

        ctx.function.Astar(start, end, hinders, 10000, out res, out mst.cell);

        if (mst.cell != null) {
            int Length = 0;
            RectCell cur = mst.cell;
            while (cur != null) {
                mst.path[Length++] = cur.position;
                cur = cur.parent;
            }
        }

    }



    public static void MoveByPath(MstEntity mst, RoleEntity role, float dt) {
        // 无路径
        if (mst.path == null || mst.path.Length == 0) {
            return;
        }
        // 到达终点
        if (mst.pathIndex >= mst.path.Length) {
            return;
        }

        Vector2Int target = mst.path[mst.pathIndex];

        Vector3 dir = new Vector3(0, 0, 0);
        dir.x = target.x - mst.transform.position.x;
        dir.z = target.y - mst.transform.position.z;

        if (dir.magnitude < 0.1f) {
            mst.isNear = true;

        } else {
            dir.Normalize();
            mst.Move(dir, dt);
        }
    }

    public static void Move(MstEntity mst, RoleEntity role, float dt) {
        Vector3 direction = role.transform.position - mst.transform.position;

        direction.Normalize();
        Debug.Log("direction" + direction);
        mst.Move(direction, dt);

        if(direction.magnitude > 0.1f) {
            mst.isNear = false;
        }
    }
    public static void Unpawn(GameContext ctx, MstEntity mst) {
        ctx.mstRespository.Remove(mst);
        mst.TearDown();
    }

}