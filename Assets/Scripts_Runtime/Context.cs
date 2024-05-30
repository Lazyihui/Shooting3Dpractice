

public class Context {

    public GameContext gameContext;

    public AssetsContext assetsContext;


    public Context() {
        assetsContext = new AssetsContext();
        gameContext = new GameContext();
    }

    public void Inject() {
        gameContext.Inject(assetsContext);
    }
}