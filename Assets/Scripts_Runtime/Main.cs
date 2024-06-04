using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Main : MonoBehaviour {

    Context ctx;
    bool isTearDown = false;

    void Awake() {
        // === init===
        ctx = new Context();
        Camera mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        
        // === Load===
        ModuleAssets.Load(ctx.assetsContext);

        // === Inject===
        ctx.Inject(mainCamera);

        Game_Business.New_Game(ctx.gameContext);
    }
    // Update is called once per frame
    void Update() {
        float dt = Time.deltaTime;

        ctx.moduleInput.Tick(dt);

        Game_Business.Tick(ctx.gameContext, dt);


    }


    void OnDestory() {
        TearDown();
    }

    void OnApplicationQuit() {
        TearDown();
    }

    void TearDown() {
        if (isTearDown) {
            return;
        }
        isTearDown = true;
        // === Unload===
        ModuleAssets.Unload(ctx.assetsContext);
    }
}
