
using System;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour
{

    private Rect Rect_DebugWin = new Rect(0, 0, Screen.width, Screen.height);
    private Rect Rect_CloseBtn = new Rect(0, 0, 50, 20);
    public static bool Show_DebugWin = false;
    public static string VideoSavedPath = string.Empty;
    public static string FacebookStatus = string.Empty;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Show_DebugWin = !Show_DebugWin;
        }
        else if (Input.touchCount > 3)
        {
            Show_DebugWin = !Show_DebugWin;
        }
    }

    void OnGUI()
    {
        if (!Show_DebugWin)
            return;
        GUI.Window(0, Rect_DebugWin, ShowDebugWindow, "--------------------Debug--------------------");

    }
   
    void ShowDebugWindow(int windowId)
    {
        if (GUI.Button(Rect_CloseBtn, "x"))
        {
            Show_DebugWin = false;
        }
       
    }
}