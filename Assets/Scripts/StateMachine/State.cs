using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface State
{
    public void Enter();
    public void Stay();
    public void Exit();
}
