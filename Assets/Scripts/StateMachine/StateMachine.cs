using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State CurrentState;

    public void ChangeState(State NextState)
    {
        CurrentState?.Exit();//檢查當前狀態是否為空 (null)。如果不是空，則調用當前狀態的 Exit 方法
        CurrentState = NextState;
        CurrentState.Enter();
    }

    public void Update()
    {
        CurrentState?.Stay(); //檢查當前狀態是否為空(null)。如果不是空，則調用當前狀態的 Stay 方法
    }
}
