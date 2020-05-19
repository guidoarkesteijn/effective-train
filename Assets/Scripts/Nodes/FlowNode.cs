using System;
using UnityEngine;
using XNode;

[Serializable]
public class Rule
{
    public bool Valid => true;
}

[Serializable]
public class Action
{

}

public class FlowNode : Node, IStartable, IStoppable, IUpdatable
{
    public bool IsStartNode => isStartNode;

    [Serializable]
    public class Empty
    {

    }
    [Input] public Empty In;
    [Input(typeConstraint = TypeConstraint.Inherited)] public Action actions;
    [Output(typeConstraint = TypeConstraint.Inherited)] public Rule rules;

    [SerializeField] private bool isStartNode = false;

    public void Start()
    {
        Start(GetInputPort("actions"));
        Start(GetOutputPort("rules"));
        Debug.Log("StartNode");
    }

    public void Update()
    {
        Update(GetInputPort("actions"));
        Update(GetOutputPort("rules"));
        
        //If valid switch state to rules next node.
    }

    public void Stop()
    {
        Debug.Log("StopNode");
        //Debug.log Stop Actions
        //Debug.log Stop Rules
    }

    private void Start(NodePort port)
    {
        foreach (var item in port.GetConnections())
        {
            if (item.node != null && item.node is IStartable startable)
            {
                startable.Start();
            }
        }
    }

    private void Update(NodePort port)
    {
        foreach (var item in port.GetConnections())
        {
            if(item.node != null && item.node is IUpdatable updatable)
            {
                updatable.Update();
            }
        }
    }

    private bool Valid(NodePort port)
    {
        foreach (var item in port.GetConnections())
        {
            if (item.node != null && item.node is IValidatable validatable)
            {
                if (validatable.Valid)
                {
                    Debug.Log("VALID: " + item.node);
                    return true;
                }
            }
        }
        return false;
    }

    private void Stop(NodePort port)
    {
        foreach (var item in port.GetConnections())
        {
            if(item.node != null && item.node is IStoppable stoppable)
            {
                stoppable.Stop();
            }
        }
    }
}
