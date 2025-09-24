using System;

public interface IInventoryInput
{
    event Action<OpenInventoryScreenSignal> OnOpen;
    event Action<OpenInventoryScreenSignal> OnClose;
}