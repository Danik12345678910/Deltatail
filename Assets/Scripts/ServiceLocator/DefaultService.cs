using System;

public abstract class DefaultService : IService
{
    public abstract Type ServiceType { get; }
    public abstract void Initialize();
}