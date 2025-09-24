using System;
using UnityEditor;

public interface IInteractInput : IService
{
    event System.Action OnInput;
}