using System;
using Unity.VisualScripting;
using UnityEngine;

public class CameraEngine : MonoBehaviour
{
    [SerializeField]
    private float m_HandleSize = 8;    
    private static CameraEngine m_Instance;
    public static CameraEngine Instance { get => m_Instance; set => m_Instance = value; }
    [SerializeField]
    private Vector2 m_CameraSize = new Vector2(1600, 900);
    private Vector2 m_Position;
    public Vector2 CameraSize
    {
        get => m_CameraSize;
        set => m_CameraSize = value;
    }

    public Vector2 Position
    {
        get => transform.position;
        set
        {
            Vector3 pos = transform.position;
            pos.x = value.x;
            pos.y = value.y;
            transform.position = pos;
        }
    }

    public float HandleSize { get => m_HandleSize; set => m_HandleSize = value; }

    public Transform m_Target;
    [Header("Camera Follow Module")]
    public FollowModule m_FollowModule;

    [Header("Camera Room Module")]
    public RoomModule m_RoomModule;

    public void Awake()
    {
        m_Instance = this;
        if(m_Target == null){
            Debug.Log("No target for camera");
            return;
        }
        SetupModule();        
    }

    public void SetupModule(){
        m_FollowModule = new FollowModule(m_Target, Vector2.up * 23, this, new Vector2(60f, 50f));     
    }

    public void LateUpdate()
    {
        m_FollowModule?.Excute();
    }

    public void OnDrawGizmos()
    {
        Utils.DrawBox(Position, m_CameraSize, Color.yellow);
        m_FollowModule?.DrawGizmos();
    }
}