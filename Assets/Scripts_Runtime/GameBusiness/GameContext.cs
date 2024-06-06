using System;
using UnityEngine;

public class GameContext {

    public GameEntity gameEntity;
    // === repository ===
    public RoleRespository roleRespository;

    public GunRespository gunRespository;

    public BulletRespository bulletRespository;

    public MstRespository mstRespository;
    public int roleRecordID;

    public int gunRecordID;

    public int bulletRecordID;

    public int mstRecordID;
    // === Inject ===
    public AssetsContext assetsContext;

    public ModuleInput moduleInput;

    public Camera mainCamera;


    public GameContext() {
        gameEntity = new GameEntity();

        roleRespository = new RoleRespository();
        gunRespository = new GunRespository();
        bulletRespository = new BulletRespository();
        mstRespository = new MstRespository()   ;

        bulletRecordID = 0;
        gunRecordID = 0;
        roleRecordID = 0;
        mstRecordID = 0;
    }

    public void Inject(AssetsContext assetsContext, ModuleInput moduleInput, Camera mainCamera) {
        this.assetsContext = assetsContext;
        this.moduleInput = moduleInput;
        this.mainCamera = mainCamera;
    }
}