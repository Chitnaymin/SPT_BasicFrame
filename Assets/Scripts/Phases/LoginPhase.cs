public class LoginPhase : Singleton<LoginPhase>, IMainPhase
{
    enum E_Status
    {
        None = 0,
        Loading,
        Login,
    }
    public void OnClear()
    {
    }

    public void OnPhase()
    {
        UIManager.Instance.ShowUI(GLOBALCONST.UIPREFAB_LOGIN);
    }

    public void OnLoad()
    {
        OnPhase();
    }

    public void OnUpdate()
    {

    }

    public void UserLogin(string account)
    {
        Main.Instance.ChangeGamePhase(E_GamePhase.Play);
        PlayPhase.Instance.ChangeLevel(E_PlayPhaseLevel.Menu);
    }

}
