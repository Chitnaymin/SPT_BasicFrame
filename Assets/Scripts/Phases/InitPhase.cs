public class InitPhase : Singleton<InitPhase>, IMainPhase
{

    public void OnClear()
    {
    }

    public void OnLoad()
    {
        UIManager.Instance.Initialize();
        PlayerDataManager.Instance.Initialize();
        GameManager.Instance.Initialize();
        OnPhase();
    }

    public void OnPhase()
    {

        Main.Instance.ChangeGamePhase(E_GamePhase.Version);
    }

    public void OnUpdate()
    {

    }

}
