using System;
[Serializable]
abstract public class InteractionActionEndingHandler : InteractionAction
{
    public abstract event Action OnEndingAction;
    public abstract override void Action();
}