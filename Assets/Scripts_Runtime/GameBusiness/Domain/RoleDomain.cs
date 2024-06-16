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
        role.pathIndex = 0;
        role.id = ctx.roleRecordID++;
        ctx.roleRespository.Add(role);
        return role;

    }

    public static void Move(RoleEntity role, Vector2 moveAxis, float speed) {
        role.Move(moveAxis, speed);
    }

    public static void Rotate(Camera camera, RoleEntity role, Vector3 mousePos, float dt) {
        Ray ray = camera.ScreenPointToRay(mousePos);
        Plane groupPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;
        // Debug.DrawLine(ray.origin, ray.direction * 100, Color.red);

        if (groupPlane.Raycast(ray, out rayDistance)) {
            Vector3 point = ray.GetPoint(rayDistance);
            // Debug.DrawLine(ray.origin, point, Color.red);
            Vector3 height = new Vector3(point.x, role.transform.position.y, point.z);
            role.transform.LookAt(height);
        }


    }

    public static void Rotate1(Camera camera, RoleEntity role, Vector3 mousePos, float dt) {

        Ray ray = camera.ScreenPointToRay(mousePos);
        Plane groupPlane = new Plane(Vector3.up, Vector3.zero);

        float rayDistance;

        if (groupPlane.Raycast(ray, out rayDistance)) {
            Vector3 point = ray.GetPoint(rayDistance);
            Vector3 direction = point - role.transform.position;
            direction.y = 0;
            // 看不懂
            Quaternion targetRot = Quaternion.LookRotation(direction);
            role.transform.rotation = Quaternion.Slerp(role.transform.rotation, targetRot, 0.1f);
        }
    }
}