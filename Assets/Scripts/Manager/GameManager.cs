using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

class GameManager : Singleton<GameManager>
{
    private bool m_Paused;
    public bool Paused { get => m_Paused; set => m_Paused = value; }  
    private static GameObject m_PlayerPoolObject;
    private static GameObject m_EnemyPoolObject;
    private static GameObject m_BossPoolObject;
    public static GameObject PlayerPoolObject { get => m_PlayerPoolObject; set => m_PlayerPoolObject = value; }
    public static GameObject EnemyPoolObject { get => m_EnemyPoolObject; set => m_EnemyPoolObject = value; }
    public static GameObject BossPoolObject { get => m_BossPoolObject; set => m_BossPoolObject = value; }

    public override void Awake()
    {
        base.Awake();
        OnAwake(this);
        m_PlayerPoolObject = new GameObject("PlayerPool");
        m_EnemyPoolObject = new GameObject("EnemyPool");
        m_BossPoolObject = new GameObject("BossPool");
    }

    public override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Paused = !Paused;
            if(Paused){
                Time.timeScale = 0;
            }else{
                Time.timeScale = 1;
            }

        }
    }
}
