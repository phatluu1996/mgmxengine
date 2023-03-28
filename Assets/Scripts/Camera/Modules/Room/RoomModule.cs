using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class RoomModule : CameraEngineModule
{
    [SerializeField]
    private Vector2 m_DefaultSize;
    public Vector2 DefaultSize { get => m_DefaultSize; set => m_DefaultSize = value; }
    [SerializeField]
    private List<Room> m_Rooms;
    public List<Room> Rooms { get => m_Rooms; set => m_Rooms = value; }

    public RoomModule()
    {
        Rooms = new List<Room>();
    }

    protected override void Update()
    {
        
    }
    
    public Room CreateRoom(Vector2 center)
    {
        return new Room(center, m_DefaultSize, this);
    }

    public Room CreateRoom(Vector2 center, Vector2 size)
    {
        return new Room(center, size, this);
    }

    public bool AddRoom(Room newRoom)
    {
        m_Rooms.Add(newRoom);
        return true;
    }
    
    public bool RemoveRoom(Room newRoom)
    {
        return m_Rooms.Remove(newRoom);
    }
    
    public override void DrawGizmos()
    {
        foreach (var room in m_Rooms)
        {
            Utils.DrawBox(room.Rectangle.Center, room.Rectangle.Size, Color.magenta);
        }
    }
}
