using System;
using UnityEngine;

[Serializable]
public class Rectangle
{
    private Bounds m_Bounds;
    [SerializeField]
    private Vector2 m_Center;
    [SerializeField]
    private Vector2 m_Size;
    private Vector2 m_TL;
    private Vector2 m_TR;
    private Vector2 m_BL;
    private Vector2 m_BR;
    [SerializeField]
    private float m_TO;
    [SerializeField]
    private float m_BO;
    [SerializeField]
    private float m_LO;
    [SerializeField]
    private float m_RO;

    public Vector2 Center { get => m_Center; set => m_Center = value; }

    public Vector2 Size { get => m_Size; set => m_Size = value; }

    public Vector2 TL => new Vector2(m_Center.x - m_Size.x / 2, m_Center.y + m_Size.y / 2);

    public Vector2 TR => new Vector2(m_Center.x + m_Size.x / 2, m_Center.y + m_Size.y / 2);

    public Vector2 BL => new Vector2(m_Center.x - m_Size.x / 2, m_Center.y - m_Size.y / 2);

    public Vector2 BR => new Vector2(m_Center.x + m_Size.x / 2, m_Center.y - m_Size.y / 2);

    public float T => TR.y;
    public float B => BR.y;
    public float L => TL.x;
    public float R => TR.x;

    public Vector2 CL;
    public Vector2 CR;
    public Vector2 CT;
    public Vector2 CB;

    public float TO => T - CT.y;
    public float BO => B - CB.y;
    public float LO => L - CL.x;
    public float RO => R - CR.x;

    public Rectangle(Vector2 center, Vector2 size)
    {
        m_Center = center;
        m_Size = size;
        m_Bounds = new Bounds(m_Center, m_Size);
        CR = new Vector2(R, m_Center.y);
        CL = new Vector2(L, m_Center.y);
        CT = new Vector2(m_Center.x, T);
        CB = new Vector2(m_Center.x, B);
    }

    public void Reset(Vector2 center, Vector2 size){
        Vector2 floatVector = center / 8; // Convert to tile units
        Vector2Int intVector = new Vector2Int(
            Mathf.FloorToInt(floatVector.x),
            Mathf.FloorToInt(floatVector.y)
        );

        // Make sure components are odd
        if (intVector.x % 2 == 0) intVector.x += 1;
        if (intVector.y % 2 == 0) intVector.y += 1;

        intVector *= Mathf.FloorToInt(8);
        center = new Vector2(intVector.x, intVector.y);
        m_Center = center;
        m_Size = size;
        m_Bounds = new Bounds(m_Center, m_Size);
        CR = new Vector2(R, m_Center.y);
        CL = new Vector2(L, m_Center.y);
        CT = new Vector2(m_Center.x, T);
        CB = new Vector2(m_Center.x, B);
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
        Vector2 offset = newCenter - m_Center;
        m_Bounds.center = newCenter;
        m_Bounds.size = newSize;
        m_Center = newCenter;
        m_Size = newSize;
        CR += offset;
        CL += offset;
        CT += offset;
        CB += offset;
    }
}