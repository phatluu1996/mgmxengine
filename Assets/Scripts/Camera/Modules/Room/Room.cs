using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Room
{
    public RoomModule m_RoomModule;
    private Rectangle m_Rectangle;
    public Rectangle Rectangle { get => m_Rectangle; set => m_Rectangle = value; }

    public Room(Vector2 center, Vector2 size, RoomModule roomModule)
    {
        m_Rectangle = new Rectangle(center, size);
        m_RoomModule = roomModule;
    }

    public void Update(Vector2 newCenter, Vector2 newSize)
    {
        Rectangle.Update(newCenter, newSize);
    }
}
