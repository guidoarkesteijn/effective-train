using XNode;

public interface IStartable
{
    void Start();
}

public interface IStoppable
{
    void Stop();
}

public interface IUpdatable
{
    void Update();
}

public interface IValidatable
{
    bool Valid { get; }
}

public abstract class BaseRule : Node, IStartable, IStoppable, IValidatable
{
    public virtual bool Valid { get; }

    [Input] public Rule In;
    [Output] public Empty Out;

    public virtual void Start()
    {

    }

    public virtual void Stop()
    {

    }
}
