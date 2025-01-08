using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateMachine
{
    void EnterState();
    void RunState(GameObject character);
    void ExitState();
}
