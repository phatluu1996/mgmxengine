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

    public override void Awake()
    {
        base.Awake();
        OnAwake(this);
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
