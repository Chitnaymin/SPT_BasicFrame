using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public static Main Instance { get { return _instance; } }
    
    private E_GamePhase _gamePhase = E_GamePhase.None;
    private IMainPhase _currentPhase = null;
    private static Main _instance = null;
    
    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
#if DEBUG_TOOL
        gameObject.AddComponent<DebugManager>();
        Debug.unityLogger.logEnabled = true;
#else
        DebugManager debugManager = gameObject.GetComponent<DebugManager>();
        if(debugManager!= null)
        {
            Destroy(debugManager);
        }
        Debug.unityLogger.logEnabled = false;
#endif
    }

    private void Start()
    {
        ChangeGamePhase(E_GamePhase.Init);
    }

    private void Update()
    {
        _currentPhase.OnUpdate();
    }

    public void ChangeGamePhase(E_GamePhase GamePhase)
    {
        _gamePhase = GamePhase;
        if (_currentPhase != null)
            _currentPhase.OnClear();
        switch (GamePhase)
        {
            case E_GamePhase.Init:
                _currentPhase = InitPhase.Instance;
                break;
            case E_GamePhase.Version:
                _currentPhase = VersionPhase.Instance;
                break;
            case E_GamePhase.Login:
                _currentPhase = LoginPhase.Instance;
                break;
            case E_GamePhase.Play:
                _currentPhase = PlayPhase.Instance;
                break;
            case E_GamePhase.None:
                break;
            default:
                _currentPhase = null;
                break;
        }

        if (_currentPhase != null)
        {
            _currentPhase.OnLoad();
        }

        Debug.Log($"Current Phase = {_currentPhase.ToString()}");
    }
}