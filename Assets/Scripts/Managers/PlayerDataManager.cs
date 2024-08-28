using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : Singleton<PlayerDataManager>
{
    public event Action EvntPlayerDataChanged;
    private PlayerData m_PlayerData;
    public PlayerData PlayerData
    {
        get
        {
            if (m_PlayerData == null) { CreatNewPlayer(); }
            return m_PlayerData;
        }
        set
        {
            if (m_PlayerData == null) { CreatNewPlayer(); }
            m_PlayerData = value;
            EvntPlayerDataChanged?.Invoke();
        }
    }
    public PlayerData LastDanceData;
    public string DisplayName;

    public bool LoadPlayerSave()
    {
        return false;
    }
    public void SavePlayerData()
    {
       
    }

    public void CreatNewPlayer()
    {
        m_PlayerData = new PlayerData();
    }
}


[Serializable]
public class PlayerData
{
   
}