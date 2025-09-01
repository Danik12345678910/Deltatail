using System;
using System.Collections.Generic;

public class ServiceLocator
{
    private Dictionary<Type, IService> _serviceMap = new Dictionary<Type, IService>();
    static public ServiceLocator Current { get; private set; }
    static public void Initialize() => Current = new ServiceLocator();
    public T GetService<T>() where T : IService
    {
        var key = typeof(T);

        if (!_serviceMap.ContainsKey(key))
            ThrowError("Ключ отсутствует.");

        var service = (T)_serviceMap[key];
        return service;
    }

    public T TryGetService<T>() where T : IService
    {
        var key = typeof(T);
        var service = (T)_serviceMap[key];
        if (service != null)
            return service;
        return default(T);
    }

    public void Register<T>(T service) where T : IService
    {
        var key = service.ServiceType;

        if (_serviceMap.ContainsKey(key))
            ThrowError("Такой ключ уже есть.");

        _serviceMap.Add(key, service);
    }

    private void ThrowError(string message) => throw new InvalidOperationException($"{typeof(ServiceLocator)}: {message}");

}
