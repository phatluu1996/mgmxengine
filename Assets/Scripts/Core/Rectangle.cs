using System;
using UnityEngine;

[Serializable]
public class Rectangle
{
    private Bounds m_Bounds;
    private Vector2 m_Center;
    private Vector2 m_Size;
    private Vector2 m_TL;
    private Vector2 m_TR;
    private Vector2 m_BL;
    private Vector2 m_BR;

    public Vector2 Center => m_Center;

    public Vector2 Size => m_Size;

    public Vector2 TL => new Vector2(m_Center.x - m_Size.x / 2, m_Center.y + m_Size.y / 2);

    public Vector2 TR => new Vector2(m_Center.x + m_Size.x / 2, m_Center.y + m_Size.y / 2);

    public Vector2 BL => new Vector2(m_Center.x - m_Size.x / 2, m_Center.y - m_Size.y / 2);

    public Vector2 BR => new Vector2(m_Center.x + m_Size.x / 2, m_Center.y - m_Size.y / 2);
    
    public Rectangle(Vector2 center, Vector2 size)
    {
        m_Center = center;
        m_Size = size;
        m_Bounds = new Bounds(m_Center, m_Size);
    }

    public bool Contains(Vector2 point)
    {
        return m_Bounds.Contains(point);
    }

    public void Update(Vector2 newCenter)
    {
        m_Bounds.center = newCenter;
        m_Center = newCenter;
    }
    
    public void Update(Vector2 newCenter, Vector2 newSize)
    {
        m_Bounds.center = newCenter;
        m_Bounds.size = newSize;
        m_Center = newCenter;
        m_Size = newSize;
    }
}