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

    // public static void Rotate(Camera camera, RoleEntity role, Vector3 mousePos, float dt) {

    //     if (Input.GetMouseButton(0)) {
    //         Vector3 cameraRotationAxis = Input.mousePositionDelta;
            
    //         cameraRotationAxis*=60f*dt;

    //         Debug.Log("cameraRotationAxis:" + cameraRotationAxis);

    //         //获取物体坐标，物体坐标是世界坐标，将其转换成屏幕坐标，和鼠标一直
    //         Vector3 roleToScreen = camera.WorldToScreenPoint(role.transform.position);
    //         //屏幕坐标向量相减，得到指向鼠标点的目标向量
    //         Vector3 direction = mousePos - roleToScreen;

    //         direction.Normalize();

    //         Quaternion oldRot = Quaternion.Euler(direction);

    //         Vector3 oldEuler = role.transform.eulerAngles;

    //         Quaternion newRot = oldRot;
    //         float targetPosX = oldEuler.x + cameraRotationAxis.y;

    //         if(targetPosX>180){
    //             targetPosX = targetPosX - 360;
    //             Quaternion yRot = Quaternion.Euler(0, oldEuler.y + cameraRotationAxis.x, oldEuler.z);
    //             role.transform.rotation = yRot;
    //         }
    //     }
    // }

    public static void Rotate(Camera camera, RoleEntity role, Vector3 mousePos, float dt) {

         Ray ray = camera.ScreenPointToRay(mousePos);
        Plane groupPlane = new Plane(Vector3.up, Vector3.zero);

        float rayDistance;

        if(groupPlane.Raycast(ray, out rayDistance)){
            Vector3 targetPos = ray.GetPoint(rayDistance);
            Vector3 direction = targetPos - role.transform.position;
            direction.y = 0;
            Quaternion targetRot = Quaternion.LookRotation(direction);
            role.transform.rotation = Quaternion.Slerp(role.transform.rotation, targetRot, 0.1f);
        }
    }
}