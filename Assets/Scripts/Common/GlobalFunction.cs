using System;
using UnityEngine;
public class GLOBALFUNCTION
{
    public static event Action EvntLanguageChanged;
    public static void SetPlayerLanguage(E_PlayerLanguage playerLanguage)
    {
        PlayerPrefs.SetInt(GLOBALCONST.PLAYER_PREF_LANGUAGE_KEY, (int)playerLanguage);
        EvntLanguageChanged?.Invoke();
    }
}
