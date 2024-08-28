using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMessageBox : UIBase
{
    [SerializeField] private Text txtTitle;
    [SerializeField] private Text txtStatus;
    [SerializeField] private Button btnClose;
    [SerializeField] private Button btnConfirm;

    private UIMesageBoxActionData ActionData;

    protected override void OnInit()
    {
        base.OnInit();
        btnClose.onClick.AddListener(OnClickCloseBtn);
        btnConfirm.onClick.AddListener(OnClickConfirm);
    }
    protected override void UpdateAllLocalizedImages()
    {
        base.UpdateAllLocalizedImages();
    }
    protected override void OnShow(UIBaseData Data = null)
    {
        if(Data!=null)
        {
            ActionData = (UIMesageBoxActionData)Data;
            txtTitle.text = ActionData.Title;
            txtStatus.text = ActionData.Content;
        }
        base.OnShow(Data);
    }
    private void OnClickCloseBtn()
    {
    }

    private void OnClickConfirm()
    {
        if(ActionData!=null)
        {
            ActionData.YesAction.Invoke();
        }
    }

    protected override void OnClose()
    {
        ActionData = null;
        base.OnClose();
    }
}
public class UIMesageBoxActionData : UIBaseData
{
    public string Title;
    public string Content;
    public System.Action YesAction;
}
