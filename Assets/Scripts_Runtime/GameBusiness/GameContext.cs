using System;
using UnityEngine;

public class GameContext {

    public GameEntity gameEntity;
    // === repository ===
    public RoleRespository roleRespository;

    public GunRespository gunRespository;
    public int roleRecordID;

    public int gunRecordID;
    // === Inject ===
    public AssetsContext assetsContext;

    public ModuleInput moduleInput;

    public Camera mainCamera;


    public GameContext() {
        gameEntity = new GameEntity();

        roleRespository = new RoleRespository();
        gunRespository = new GunRespository();
        gunRecordID = 0;
        roleRecordID = 0;
    }

    public void Inject(AssetsContext assetsContext, ModuleInput moduleInput, Camera mainCamera) {
        this.assetsContext = assetsContext;
        this.moduleInput = moduleInput;
        this.mainCamera = mainCamera;
    }
}