using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class InputHandler
{
    private bool m_AxisXUnlocked;
    public bool AxisXUnlocked { get => m_AxisXUnlocked; set => m_AxisXUnlocked = value; }
    private InputKey m_Up, m_Down, m_Left, m_Right, m_Dash, m_Jump, m_Attack, m_SpAttack;
    public InputKey Up { get => m_Up; set => m_Up = value; }
    public InputKey Down { get => m_Down; set => m_Down = value; }
    public InputKey Left { get => m_Left; set => m_Left = value; }
    public InputKey Right { get => m_Right; set => m_Right = value; }
    public InputKey Jump { get => m_Jump; set => m_Jump = value; }
    public InputKey Dash { get => m_Dash; set => m_Dash = value; }
    public InputKey Attack { get => m_Attack; set => m_Attack = value; }

    public InputHandler()
    {
        m_AxisXUnlocked = true;
        Up = new InputKey(KeyCode.W);
        Down = new InputKey(KeyCode.S);
        Left = new InputKey(KeyCode.A);
        Right = new InputKey(KeyCode.D);
        Dash = new InputKey(KeyCode.L);
        Jump = new InputKey(KeyCode.K);
        Attack = new InputKey(KeyCode.J);
    }

    public void Check()
    {
        Up.Check();
        Down.Check();
        Left.Check();
        Right.Check();
        Dash.Check();
        Jump.Check();
        Attack.Check();
    }

    public float AxisXHold { get => m_AxisXUnlocked ? (Right.Hold.GetHashCode() - Left.Hold.GetHashCode()) : 0; }
    public float AxisXPressed { get => m_AxisXUnlocked ? (Right.Pressed.GetHashCode() - Left.Pressed.GetHashCode()) : 0; }

    public float AxisYHold { get => Up.Hold.GetHashCode() - Down.Hold.GetHashCode(); }
    public float AxisYPressed { get => Up.Pressed.GetHashCode() - Down.Pressed.GetHashCode(); }
}
