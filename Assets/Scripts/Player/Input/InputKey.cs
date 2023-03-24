using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class InputKey
{
    private KeyCode m_KeyCode;
    private bool m_IsPressed;
    private bool m_IsReleased;
    private bool m_IsHold;

    public bool IsPressed { get => m_IsPressed; set => m_IsPressed = value; }
    public bool IsReleased { get => m_IsReleased; set => m_IsReleased = value; }
    public bool IsHold { get => m_IsHold; set => m_IsHold = value; }
    public KeyCode KeyCode { get => m_KeyCode; set => m_KeyCode = value; }

    public InputKey(KeyCode keyCode)
    {
        m_KeyCode = keyCode;
        m_IsPressed = false;
        m_IsReleased = false;
        m_IsHold = false;
    }

    public void Check()
    {
        m_IsPressed = Input.GetKeyDown(m_KeyCode);
        m_IsHold = Input.GetKey(m_KeyCode);
        m_IsReleased = Input.GetKeyUp(m_KeyCode);
    }
}
