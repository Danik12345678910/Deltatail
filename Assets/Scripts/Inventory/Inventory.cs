using System;
using UnityEngine;

public class Inventory : MonoBehaviourService
{
    public override Type ServiceType => throw new NotImplementedException();

    private ItemData[] _items;

    private EventBus _bus;
    private IInventoryInput _input;

    public void Initialize(IInventoryInput input)
    { 
        _input = input;
        _input.OnOpen += _bus.Invoke;
    }
}