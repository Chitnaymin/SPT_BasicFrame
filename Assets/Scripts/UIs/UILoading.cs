using UnityEngine;
using UnityEngine.UI;

public class UILoading : UIBase
{
    public RawImage LoadingImage;
    public float RotationSpeed;
    public Text Counter;
    private int m_Count;
    protected override void OnInit()
    {
        base.OnInit();
    }


    protected override void OnShow(UIBaseData Data = null)
    {
        base.OnShow(Data);
        m_Count = 0;
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();

    }

    private void FixedUpdate()
    {
        LoadingImage.transform.Rotate(Vector3.forward * RotationSpeed);
        m_Count += 1;
        Counter.text = m_Count.ToString();
    }

}

public class UILoadingData : UIBaseData
{
}
