using System;

[Serializable]
public abstract class InteractionAction
{
    virtual public void Initialize() { }
    virtual public void Disable() { }
    abstract public void Action();
}