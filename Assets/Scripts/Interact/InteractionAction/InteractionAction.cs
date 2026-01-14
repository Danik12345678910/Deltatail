using System;

[Serializable]
public abstract class InteractionAction
{
    virtual public void Start() { }
    virtual public void Disable() { }
    virtual public void Initialize(InteractDependencyPack pack) { }
    abstract public void Action();
}