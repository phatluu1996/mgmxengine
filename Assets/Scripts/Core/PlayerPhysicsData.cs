using UnityEngine;

[CreateAssetMenu(fileName = "PlayerPhysicsData", menuName = "mgmxengine/PlayerPhysicsData", order = 2)]
public class PlayerPhysicsData : ScriptableObject {
    [SerializeField]
    private float m_Gravity;
    public float Gravity { get => m_Gravity; set => m_Gravity = value; }
    [SerializeField]
    private float m_RunSpeed;
    public float RunSpeed { get => m_RunSpeed; set => m_RunSpeed = value; }        
}