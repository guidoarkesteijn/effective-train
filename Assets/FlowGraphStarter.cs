using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowGraphStarter : MonoBehaviour
{
    [SerializeField] private FlowNodeGraph flowNodeGraph = null;

    private FlowNodeGraph instance;

    protected void Awake()
    {
         instance = Instantiate(flowNodeGraph);
    }

    protected void Start()
    {
        instance.Start();
    }

    protected void Update()
    {
        instance.Update();
    }

    protected void LateUpdate()
    {
        instance.LateUpdate();
    }

    protected void OnDestroy()
    {
        instance.Stop();
    }
}
