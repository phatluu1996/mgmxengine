using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class Singleton<T> : Entity where T : class
{
    private static T m_Instance;
    public static T Instance { get => m_Instance; set => m_Instance = value; }

    public void OnAwake(T inst)
    {
        if(m_Instance == null)
        {
            m_Instance = inst;
            DontDestroyOnLoad(this);
            return;
        }
    }
}
