using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using XNode;

[CreateAssetMenu]
public class FlowNodeGraph : NodeGraph
{
    private FlowNode CurrentNode;
    private FlowNode[] flowNodes => nodes.Where(x => x.GetType() == typeof(FlowNode)).ToList().ConvertAll<FlowNode>(x => (FlowNode)x).ToArray();

    public void Start()
    {
        FlowNode startNode = flowNodes.FirstOrDefault(x => x.IsStartNode);
        SwitchNode(startNode);
        Debug.Log("Started");
    }

    public void Update()
    {
        if(CurrentNode != null && CurrentNode is IUpdatable updatable)
        {
            updatable.Update();
        }
    }

    public void LateUpdate()
    {
    }

    public void Stop()
    {
        StopNode(CurrentNode);
    }

    private void SwitchNode(FlowNode nextNode)
    {
        StopNode(CurrentNode);

        CurrentNode = nextNode;

        StartNode(CurrentNode);
    }

    private void StopNode(FlowNode flowNode)
    {
        if (flowNode != null && flowNode is IStoppable stoppable)
        {
            stoppable.Stop();
        }
    }

    private void StartNode(FlowNode flowNode)
    {
        if (flowNode != null && flowNode is IStartable startable)
        {
            startable.Start();
        }
    }

    public override void Clear()
    {
        //WHAT TO DO?
    }

    protected override void OnDestroy()
    {
        //What TO DO
    }
}