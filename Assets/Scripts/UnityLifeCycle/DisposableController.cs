using System;
using UnityEngine;
using Zenject;

sealed internal class DisposableController : MonoBehaviour
{
    private IDisposable[] _disposables;

    [Inject]
    private void Initialize(IDisposable[] disposables) => _disposables = disposables;

    private void OnDestroy()
    {
        foreach (var disposable in _disposables)
            disposable.Dispose();
    }
}