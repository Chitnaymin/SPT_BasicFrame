using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    private const string NAME_UIROOT = "UIRoot";
    private const string NAME_UIROOT_STATIC = "UIRoot_Static";
    private const string NAME_UICAMERA = "UICamera";

    private static Dictionary<string, UIBase> _uiMap = new Dictionary<string, UIBase>();
    private static List<UIBase> _openingUI = new List<UIBase>();
    private static UIBase _catchUI;
    private static List<GameObject> _uiEffect = new List<GameObject>();
    private Transform _uiRoot;
    private Transform _uiRootStatic;
    private Camera _uiCamera;

    public Camera UICamera
    {
        get { return _uiCamera; }
    }

    private void SortUI()
    {
        if (_openingUI == null)
            return;

        int Count = -1;
        for (int i = _openingUI.Count - 1; i >= 0; i--)
        {
            _openingUI[i].SortOrder = Count;
            _openingUI[i].Depth = Count * -10;
            Count--;
        }
        if (_openingUI.Count > 0)
            _openingUI[_openingUI.Count - 1].Focus();


        //To let UILoading visible over any other UI when it is active
        if (UIInstance<UILoading>() != null)
        {
            UIInstance<UILoading>().SortOrder = 0;
        }
    }

    public override void Initialize()
    {
        base.Initialize();
        GameObject UIRooTObj = GameObject.Find(NAME_UIROOT);
        Object.DontDestroyOnLoad(UIRooTObj);
        _uiRoot = UIRooTObj.transform;

        GameObject UIRootStaticObj = GameObject.Find(NAME_UIROOT_STATIC);
        Object.DontDestroyOnLoad(UIRootStaticObj);
        _uiRootStatic = UIRootStaticObj.transform;

        GameObject UICameraObj = GameObject.Find(NAME_UICAMERA);

        _uiCamera = Camera.main;
    }
    public void ShowUI(string UIName, UIBaseData Data = null)
    {
        if (!_uiMap.ContainsKey(UIName))
        {
            UIBase UIAsset = Resources.Load<UIBase>(string.Format(GLOBALCONST.FORMAT_UIPREFAB_PATH, UIName));
            if (UIAsset == null)
            {
                Debug.LogError(string.Format("load UI failed :{0}", UIName));
                return;
            }
            else
            {
                Debug.Log($"UI Found with name {UIAsset.name}");
            }
            UIBase UI = Object.Instantiate(UIAsset) as UIBase;
            UI.gameObject.name = UIName;
            if (UI.IsStatic)
                UI.transform.SetParent(_uiRootStatic);
            else
                UI.transform.SetParent(_uiRoot);
            UI.Init();
            UI.gameObject.SetActive(false);
            _uiMap.Add(UIName, UI);
        }

        if (_uiMap[UIName] == null)
        {
            Debug.Log(string.Format("UI not in UIMap :{0}", UIName));
            return;
        }
        if (_openingUI.Count > 0)
            _openingUI[_openingUI.Count - 1].Defocus();
        if (_openingUI.Contains(_uiMap[UIName]))
            _openingUI.Remove(_uiMap[UIName]);
        _openingUI.Add(_uiMap[UIName]);
        _uiMap[UIName].Show(Data);
        SortUI();
    }

    public void CloseUI(string UIName)
    {
        if (!_uiMap.ContainsKey(UIName))
            return;
        if (_uiMap[UIName] == null)
            return;
        if (_openingUI.Contains(_uiMap[UIName]))
            _openingUI.Remove(_uiMap[UIName]);
        _uiMap[UIName].Close();
        SortUI();
    }

    public void CloseAllOpeningUIs()
    {
        for (int i = 0; i < _openingUI.Count; i++)
        {
            _openingUI[i].Close();
        }
        _openingUI.Clear();
    }

    public bool IsOpened(string UIName)
    {
        if (!_uiMap.ContainsKey(UIName))
            return false;
        return _uiMap[UIName].Opened;
    }

    public void LoadSceneClear()
    {

        for (int i = _uiRoot.transform.childCount - 1; i >= 0; i--)
        {
            Transform UI = _uiRoot.GetChild(i);
            if (UI == null)
                continue;
            if (_uiMap.ContainsKey(UI.name))
                _uiMap.Remove(UI.name);
            Object.Destroy(UI.gameObject);
        }
        _openingUI.Clear();


        for (int i = 0; i < _uiEffect.Count; i++)
        {
            GameObject.Destroy(_uiEffect[i]);
        }
        _uiEffect.Clear();

    }


    public static T UIInstance<T>() where T : UIBase
    {
        if (_catchUI != null && _catchUI is T)
            return _catchUI as T;

        for (int i = 0; i < _openingUI.Count; i++)
        {
            if (_openingUI[i] is T)
            {
                _catchUI = _openingUI[i];
                return _openingUI[i] as T;
            }
        }
        return null;
    }

    public UIBase GetUIBase(string uiName)
    {
        if (!_uiMap.ContainsKey(uiName))
            return null;
        return _uiMap[uiName];
    }
}
