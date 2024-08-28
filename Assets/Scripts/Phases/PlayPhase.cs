public class PlayPhase : Singleton<PlayPhase>, IMainPhase
{

    private IPlayLevel m_CurrentLevel;
    private bool m_LevelLoadResource = false;
    private E_PlayPhaseLevel m_PlayLevel;
    public E_PlayPhaseLevel NowPlayLevel
    {
        get { return m_PlayLevel; }
    }


    public void OnClear()
    {
    }

    public void OnPhase()
    {
    }

    public void OnUpdate()
    {
        if (m_CurrentLevel == null)
            return;
        if (m_LevelLoadResource)
        {
            m_LevelLoadResource = false;
            m_CurrentLevel.OnLevel();
        }

        m_CurrentLevel.OnUpdate();
    }


    public void ChangeLevel(E_PlayPhaseLevel level, params object[] Objects)
    {
        m_PlayLevel = level;
        if (m_CurrentLevel != null)
            m_CurrentLevel.OnClear();
        switch (level)
        {
            case E_PlayPhaseLevel.Menu:
                m_CurrentLevel = MenuLevel.Instance;
                break;
            case E_PlayPhaseLevel.Play:
                m_CurrentLevel = PlayLevel.Instance;
                break;
            case E_PlayPhaseLevel.GameOver:
                break;
            default:
                break;
        }
        if (m_CurrentLevel != null)
        {
            //UIManager.Instance.ShowUI(GLOBALCONST.UI_LOADING);
            m_CurrentLevel.OnLoad();
            m_LevelLoadResource = true;
        }
    }

    public void OnLoad()
    {
    }
}
