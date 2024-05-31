using System;
using UnityEngine;


public static class RoleDomain {

    public static RoleEntity Spawn(GameContext ctx) {  

        bool has = ctx.assetsContext.TryGetEntity("Role_Entity", out GameObject prefab);

        if (!has) {
            Debug.LogError("Role_Entity not found");
            return null;
        }

        RoleEntity role = GameObject.Instantiate(prefab).GetComponent<RoleEntity>();

        role.Ctor(); 
        role.id = ctx.roleID++;
        ctx.roleRespository.Add(role);
        return role;

    }

    public static void Move(RoleEntity role, Vector2 moveAxis, float speed, float dt) {
        Debug.Log("Move");
        role.Move(moveAxis, speed, dt);
    }
}