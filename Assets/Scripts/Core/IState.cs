using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    public void OnFinish(int index);
    public void OnTrigger(int index);    
    public void OnEnter();
    public void OnExit();
    public void OnUpdate();
}
