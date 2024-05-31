

public class Context {

    public GameContext gameContext;

    public AssetsContext assetsContext;

    public ModuleInput moduleInput ;

    public Context() {
        assetsContext = new AssetsContext();
        gameContext = new GameContext();
        moduleInput  = new ModuleInput();
    }

    public void Inject() {
        gameContext.Inject(assetsContext,moduleInput);
    }
}