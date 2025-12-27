using System.Linq;
using UnityEngine;
using Zenject;

sealed internal class Bootstrap : MonoBehaviour
{
    private IStartable[] _startables;

    [Inject]
    private void Initialize(IStartable[] startables) => _startables = startables;

    private void Start()
    {
        _startables = _startables.OrderBy(startable => startable.Priority).ToArray();

        foreach (var startables in _startables)
            startables.Start();
    }
}
