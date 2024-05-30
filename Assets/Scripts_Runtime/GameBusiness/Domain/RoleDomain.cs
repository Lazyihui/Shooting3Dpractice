using System;
using UnityEngine;


public static class RoleDomain {

    public static RoleEntity Spawn(GameContext ctx) {  
        Debug.Assert(ctx != null, "ctx is null");
        Debug.Assert(ctx.assetsContext != null, "ctx.assetsContext is null");
        Debug.Assert(ctx.roleRespository != null, "ctx.roleRespository is null");

        bool has = ctx.assetsContext.TryGetEntity("Role_Entity", out GameObject prefab);

        if (!has) {
            Debug.LogError("Role_Entity not found");
            return null;
        }

        RoleEntity role = GameObject.Instantiate(prefab).GetComponent<RoleEntity>();

        role.Ctor(); 

        ctx.roleRespository.Add(role);
        return role;

    }

}