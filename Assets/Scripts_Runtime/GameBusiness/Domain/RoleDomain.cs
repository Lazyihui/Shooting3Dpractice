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
        role.Move(moveAxis, speed, dt);
    }

    public static void Rotate(Camera camera, RoleEntity role, Vector3 mousePos, float dt) {

        if (Input.GetMouseButton(0)) {


            //获取物体坐标，物体坐标是世界坐标，将其转换成屏幕坐标，和鼠标一直
            Vector3 roleToScreen = camera.WorldToScreenPoint(role.transform.position);
            //屏幕坐标向量相减，得到指向鼠标点的目标向量
            Vector3 direction = mousePos - roleToScreen;

            //将目标向量长度变成1，即单位向量，这里的目的是只使用向量的方向，不需要长度，所以变成1
            // // direction.Normalize();
            // Debug.Log("direction:" + direction);
            // //角色只需要在水平面上旋转
            // // direction.y = 0;

            // //将角色的前方向转换成世界坐标
            // Vector3 roleForward = role.transform.forward;
            // roleForward.y = 0;

            // //计算角色的前方向和目标向量的夹角
            // float angle = Vector3.SignedAngle(roleForward, direction, Vector3.up);

            // //将角色的前方向转向目标向量
            // role.transform.Rotate(Vector3.up, angle * dt * 10);

            direction.z =0f;
            //角色只需要在水平面上旋转
            if(direction!=Vector3.zero){
                role.transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
            }


        }
    }
}