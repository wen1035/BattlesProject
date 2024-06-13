using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineMain : MonoBehaviour
{
    StateMachine stateMachine = new StateMachine();
    StateA stateA = new StateA();
    StateB stateB = new StateB();
    StateC stateC = new StateC();

    public  void Start()
    {
        stateMachine.ChangeState(stateA);
    }

    public  void Update()
    {
        stateMachine.Update();

        if (Input.GetKeyDown(KeyCode.B))
        {
            stateMachine.ChangeState(stateB);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            stateMachine.ChangeState(stateC);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            stateMachine.ChangeState(stateA);
        }
    }
}
