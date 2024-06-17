using System;
using System.Collections.Generic;
using UnityEngine;

public class GameContext {

    public List<Vector2Int> hinderList;

    public GameEntity gameEntity;
    // === repository ===
    public RoleRespository roleRespository;

    public GunRespository gunRespository;

    public BulletRespository bulletRespository;

    public MstRespository mstRespository;

    public HinderRepository hinderRepository;

    public int HinderRecordID;
    public int roleRecordID;

    public int gunRecordID;

    public int bulletRecordID;

    public int mstRecordID;
    // === Inject ===
    public AssetsContext assetsContext;

    public ModuleInput moduleInput;

    public Camera mainCamera;

    public Function function;



    public GameContext() {
        hinderList = new List<Vector2Int>();
        gameEntity = new GameEntity();

        roleRespository = new RoleRespository();
        gunRespository = new GunRespository();
        bulletRespository = new BulletRespository();
        mstRespository = new MstRespository();
        hinderRepository = new HinderRepository();

        bulletRecordID = 0;
        gunRecordID = 0;
        roleRecordID = 0;
        mstRecordID = 0;
    }

    public void Inject(AssetsContext assetsContext, ModuleInput moduleInput, Camera mainCamera, Function function) {
        this.assetsContext = assetsContext;
        this.moduleInput = moduleInput;
        this.mainCamera = mainCamera;
        this.function = function;
    }
}