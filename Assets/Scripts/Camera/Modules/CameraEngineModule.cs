using UnityEngine;

public abstract class CameraEngineModule
{
    private bool m_Enable = false;
    public CameraEngine m_CameraEngine { get; set; }
    public bool Enable { get => m_Enable; set => m_Enable = value; }
    
    protected abstract void Update();

    public virtual void Excute()
    {
        if(Time.deltaTime != 0 && m_Enable)
        {
            Update();
        }
    }
    
    public abstract void DrawGizmos();
}