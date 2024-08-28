using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public override void Initialize()
    {
        base.Initialize();
        PlayerDataManager.Instance.EvntPlayerDataChanged += Instance_EvntPlayerDataChanged;
    }

    private void OnSceneLoaded(Scene SceneLoaded, LoadSceneMode SceneLoadedMode)
    {
        if (SceneLoaded.name.Equals("Game"))
        {
            Debug.Log("GameSceneLoaded");
        }
    }

    private void Instance_EvntPlayerDataChanged()
    {
        Debug.Log("PlayerData Changed");
    }
   

}
