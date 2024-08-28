public class VersionPhase : Singleton<VersionPhase>, IMainPhase
{
    private enum E_Status
    {
        None = 0,
        CheckVersion,
        AskVersion,
        DownloadVersion,
        CheckResource,
        AskResource,
        DownloadResource,
        Finish,
    }

    public void OnClear()
    {
    }

    public void OnPhase()
    {
        ChangeStatus(E_Status.Finish);
    }

    public void OnUpdate()
    {
    }

    private void ChangeStatus(E_Status Status)
    {
        switch (Status)
        {
            case E_Status.CheckVersion:
                break;
            case E_Status.AskVersion:
                break;
            case E_Status.DownloadVersion:
                break;
            case E_Status.CheckResource:
                break;
            case E_Status.AskResource:
                break;
            case E_Status.DownloadResource:
                break;
            case E_Status.Finish:
                Main.Instance.ChangeGamePhase(E_GamePhase.Login);
                break;
            case E_Status.None:
                break;
            default:
                break;
        }
    }

    public void OnLoad()
    {
        OnPhase();
    }
}
