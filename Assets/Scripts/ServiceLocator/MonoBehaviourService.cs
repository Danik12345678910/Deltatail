using System;
using UnityEngine;

abstract public class MonoBehaviourService : MonoBehaviour, IService
{
    abstract public Type ServiceType { get; }
}