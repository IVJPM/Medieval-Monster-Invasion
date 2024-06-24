using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField] State currentState;
    void Update()
    {
        RunStatemachine();
    }

    private void RunStatemachine()
    {
        State nextState = currentState?.RunCurrentState();

        if(nextState != null )
        {
            SwitchToNextState(nextState);
        }
    }

    private void SwitchToNextState(State nextState)
    {
        currentState = nextState;
    }
}
