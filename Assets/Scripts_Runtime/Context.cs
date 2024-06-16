using UnityEngine;

public class Context {

    public GameContext gameContext;

    public AssetsContext assetsContext;

    public ModuleInput moduleInput;

    public Function function;


    public Context() {
        assetsContext = new AssetsContext();
        gameContext = new GameContext();
        moduleInput = new ModuleInput();
        function = new Function();
    }


    public void Inject(Camera mainCamera) {
        gameContext.Inject(assetsContext, moduleInput, mainCamera,function);
    }
}