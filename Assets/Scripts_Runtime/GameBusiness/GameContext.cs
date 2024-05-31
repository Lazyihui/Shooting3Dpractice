using System;
using UnityEngine;

public class GameContext {

    public GameEntity gameEntity;
    // === repository ===
    public RoleRespository roleRespository;
    // === Inject ===
    public AssetsContext assetsContext;

    public ModuleInput moduleInput;


    public GameContext() {
        gameEntity = new GameEntity();

        roleRespository = new RoleRespository();
    }

    public void Inject(AssetsContext assetsContext, ModuleInput moduleInput) {
        this.assetsContext = assetsContext;
        this.moduleInput = moduleInput;
    }
}