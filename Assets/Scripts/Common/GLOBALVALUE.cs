using UnityEngine;

public class GLOBALVALUE
{
    public const float UIANIMATIONCUSTOMIZATION_IMGSOUNDINDICATOR_FILLDURATION = 30f;
    public static bool IS_PLAYING_FROM_ADMIN_PANEL;
    public static bool IS_MULTI_PLAYER_DANCE_MODE;
    
    public static E_PlayerLanguage PLAYER_LANGUAGE
    {
        get { return (E_PlayerLanguage)PlayerPrefs.GetInt(GLOBALCONST.PLAYER_PREF_LANGUAGE_KEY, (int)E_PlayerLanguage.English); }
    }
    
    public static float SOUND_VOLUME
    {
        get { return PlayerPrefs.GetFloat(GLOBALCONST.PLAYER_PREF_SOUND_VOLUME, 1f); }
        set { PlayerPrefs.SetFloat(GLOBALCONST.PLAYER_PREF_SOUND_VOLUME, value); }
    }
}
