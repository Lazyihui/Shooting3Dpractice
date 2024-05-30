using System;
using UnityEngine;

public class GameContext {

    public GameEntity gameEntity;
// === repository ===
    public RoleRespository roleRespository;
// === Inject ===
    public AssetsContext assetsContext;


    public GameContext() {
        gameEntity = new GameEntity();

        roleRespository = new RoleRespository();
    }

    public void Inject(AssetsContext assetsContext) {
        this.assetsContext = assetsContext;
    }
}