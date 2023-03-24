﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class InputHandler
{
    private InputKey m_Up, m_Down, m_Left, m_Right;
    
    public InputKey Up { get => m_Up; set => m_Up = value; }
    public InputKey Down { get => m_Down; set => m_Down = value; }
    public InputKey Left { get => m_Left; set => m_Left = value; }
    public InputKey Right { get => m_Right; set => m_Right = value; }

    public InputHandler()
    {
        Up = new InputKey(KeyCode.W);
        Down = new InputKey(KeyCode.S);
        Left = new InputKey(KeyCode.A);
        Right = new InputKey(KeyCode.D);
    }

    public void Check() {
        Up.Check();        
        Down.Check();
        Left.Check();
        Right.Check();
    }

    public float AxisXHold { get => Right.IsHold.GetHashCode() - Left.IsHold.GetHashCode(); }
    public float AxisXPressed { get => Right.IsPressed.GetHashCode() - Left.IsPressed.GetHashCode(); }
}
