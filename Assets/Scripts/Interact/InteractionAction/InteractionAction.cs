using System;

[Serializable]
public abstract class InteractionAction
{
    virtual public void Start() { }
    virtual public void Disable() { }
    abstract public void Action();
}