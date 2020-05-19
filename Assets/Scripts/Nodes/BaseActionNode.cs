using XNode;

public abstract class BaseAction : Node, IStartable, IStoppable
{
    [Output] public Action Out;

    public virtual void Start()
    {

    }

    public virtual void Stop()
    {

    }
}