public class MenuLevel : Singleton<MenuLevel>, IPlayLevel
{
    public void OnClear()
    {
    }

    public void OnLevel()
    {
        PlayPhase.Instance.ChangeLevel(E_PlayPhaseLevel.Play);
    }

    public void OnLoad()
    {
    }

    public void OnUpdate()
    {
    }
}
