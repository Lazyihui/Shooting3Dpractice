using System;
using UnityEngine;


public class ModuleCamera {
    public Camera mainCamera;

    public ModuleCamera() { }

    public void Inject(Camera mainCamera) {
        this.mainCamera = mainCamera;
    }

    
    public void Round(Vector3 targetPos, Vector2 rotateAxisCamera, Vector2 followOffset, float radius, float dt) {

    }
}