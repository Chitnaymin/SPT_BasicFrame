public enum E_DebugLogType
{
    None = 0,
    Warning,
    Error,
    Protocol,
}

public enum E_GamePhase
{
    None = 0,
    Init,
    Version,
    Login,
    Play,
}

public enum E_PlayPhaseLevel
{
    Menu,
    Play,
    GameOver,
}

public enum E_MessageBoxType : byte
{
    Informative, //No Buttons 
    Confirm, //Only 'Yes' Button
    Choose, //'Yes' and 'No' Buttons
}

public enum E_PlayerLanguage : int
{
    English = 0,
    Myanmar = 1,
}