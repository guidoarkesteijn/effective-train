using UnityEngine;
using XNode;

[CreateNodeMenu("Rule/EventRule")]
public class EventRule : BaseRule
{
    [SerializeField] private string eventType;
}
