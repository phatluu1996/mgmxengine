using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : Entity
{
    private Player m_Player;
    [SerializeField]
    private BoxCollider2D m_Box2D;
    public BoxCollider2D Box2D { get => m_Box2D; set => m_Box2D = value; }
    [SerializeField]
    private LayerMask m_CollisionMask;
    public LayerMask CollisionMask { get => m_CollisionMask; set => m_CollisionMask = value; }
    public GameObject m_OneWayObject;
    public GameObject OneWayObject { get => m_OneWayObject; set => m_OneWayObject = value; }
    public override void Start()
    {
        base.Start();
        m_Player = Player.Instance;
    }
    public override void Update()
    {
        base.Update();
        if (SR.isVisible && Time.deltaTime != 0)
        {
            if (Box2D.bounds.max.y <= m_Player.y + 0.15f)
            {
                OneWayObject.SetActive(true);
            }
            else
            {
                OneWayObject.SetActive(false);
            }
        }
    }
}
