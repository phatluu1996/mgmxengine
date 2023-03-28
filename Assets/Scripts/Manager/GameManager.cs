using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

class GameManager : Singleton<GameManager>
{

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
    }
}
