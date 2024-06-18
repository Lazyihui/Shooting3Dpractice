
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
        mst.path = new Vector2Int[20000];
        mst.pathIndex = 0;
        mst.moveSpeed = 3f;
        mst.isNear = false;
        mst.id = ctx.mstRecordID++;
        mst.SetPos(new Vector3(-5, 0, 1));
        ctx.mstRespository.Add(mst);

        return mst;

    }


    public static void FindPath(GameContext ctx, MstEntity mst, RoleEntity role, List<Vector2Int> hinders) {
        Vector2Int start = mst.logicPos;
        Vector2Int end = new Vector2Int((int)role.transform.position.x, (int)role.transform.position.z);

        mst.pathCount = ctx.function.Astar(start, end, hinders, 10000, out int res, out RectCell cell);

        if (res != 1) {
            Debug.LogError("没找到" + res);
            return;
        }

        if (cell != null) {
            int Length = 0;
            RectCell cur = cell;
            while (cur != null) {
                mst.path[Length++] = cur.position;
                cur = cur.parent;
            }
        }

    }



    public static void MoveByPath(MstEntity mst, RoleEntity role, float dt) {
        // 无路径
        if (mst.path == null) {
            return;
        }
        // 到达终点
        if (mst.pathIndex >= mst.pathCount) {
            return;
        }

        if (mst.pathCount <= 1) {
            return;
        }

        for (int i = mst.pathCount - 1; i >= 0; i -= 1) {
            Vector2Int path = mst.path[i];
            Debug.DrawLine(new Vector3(path.x, 0, path.y), new Vector3(path.x, 0, path.y) + Vector3.up * 2, Color.red);
        }

        Vector2Int target = mst.path[mst.pathCount - 2];

        Vector3 dir = new Vector3(0, 0, 0);
        dir.x = target.x - mst.transform.position.x;
        dir.z = target.y - mst.transform.position.z;

        if (dir.magnitude < mst.moveSpeed * dt) {
            // mst.isNear = true;
            mst.logicPos = target;
            mst.transform.position = new Vector3(target.x, mst.transform.position.y, target.y);
        } else {
            dir.Normalize();
            mst.Move(dir, dt);
            // mst.pathIndex++;
        }
    }

    public static void Move(MstEntity mst, RoleEntity role, float dt) {
        Vector3 direction = role.transform.position - mst.transform.position;

        direction.Normalize();
        Debug.Log("direction" + direction);
        mst.Move(direction, dt);

        if (direction.magnitude > 0.1f) {
            mst.isNear = false;
        }
    }
    public static void Unpawn(GameContext ctx, MstEntity mst) {
        ctx.mstRespository.Remove(mst);
        mst.TearDown();
    }

}