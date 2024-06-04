using System;
using UnityEngine;

public class GameContext {

    public GameEntity gameEntity;
    // === repository ===
    public RoleRespository roleRespository;

    public int roleID;
    // === Inject ===
    public AssetsContext assetsContext;

    public ModuleInput moduleInput;

    public Camera mainCamera;


    public GameContext() {
        gameEntity = new GameEntity();

        roleRespository = new RoleRespository();
        roleID = 0;
    }

    public void Inject(AssetsContext assetsContext, ModuleInput moduleInput, Camera mainCamera) {
        this.assetsContext = assetsContext;
        this.moduleInput = moduleInput;
        this.mainCamera = mainCamera;
    }
}