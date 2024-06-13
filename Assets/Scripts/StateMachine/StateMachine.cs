using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State CurrentState;

    public void ChangeState(State NextState)
    {
        CurrentState?.Exit();//�ˬd��e���A�O�_���� (null)�C�p�G���O�šA�h�եη�e���A�� Exit ��k
        CurrentState = NextState;
        CurrentState.Enter();
    }

    public void Update()
    {
        CurrentState?.Stay(); //�ˬd��e���A�O�_����(null)�C�p�G���O�šA�h�եη�e���A�� Stay ��k
    }
}
