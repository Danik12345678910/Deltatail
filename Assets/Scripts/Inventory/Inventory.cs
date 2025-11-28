using System;
using UnityEngine;

public class Inventory : IDisposable
{
    private ItemData[] _items;

    private EventBus _bus;
    private IInventoryInput _input;

    public Inventory(IInventoryInput input, EventBus eventBus)
    { 
        _input = input;
        _bus = eventBus;
        _input.OnOpen += OnOpenHandler;
    }

    private void OnOpenHandler(OpenInventoryScreenSignal signal) => _bus.Invoke<OpenInventoryScreenSignal>(signal);

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}