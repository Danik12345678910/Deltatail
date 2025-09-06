using System;
using UnityEditor;

public interface IInteractInput : IService
{
    event Action OnInput;
}