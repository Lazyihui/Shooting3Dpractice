using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    Context ctx;
    bool isTearDown = false;

    void Awake() {
        // === init===
        ctx = new Context();
        // === Load===
        ModuleAssets.Load(ctx.assetsContext);
        Debug.Log("Main Awake");

        Debug.Assert(ctx != null, "ctx is null");
        ctx.Inject();

        Game_Business.New_Game(ctx.gameContext);
        // === Inject===
    }
    // Update is called once per frame
    void Update() {
        float dt = Time.deltaTime;
        
        ctx.moduleInput.Tick(dt);




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
