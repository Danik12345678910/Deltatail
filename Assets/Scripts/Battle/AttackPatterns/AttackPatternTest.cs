using System.Collections;
using UnityEngine;

public class AttackPatternTest : IAttackPattern
{
    public ObjectUnityPool<Projectile> Pool { get; private set; }
    private Vector2 _positionSpawn;
    [SerializeField] private Projectile _projectile;

    public void Initialize()
    {
        _positionSpawn = ServiceLocator.Current.GetService<Area>().GetArenaPoint(Horizontal.Center, Vertical.Center);
        Pool.Initialize(_projectile, 3, 20);
    }

    public IEnumerator Execute()
    {
        for (int i = 0; i < 10; i++)
        {
            Spawn();
            yield return new WaitForSeconds(1.5f);
        }
    }

    private void Spawn()
    {
        var pool = Pool.Get();
        pool.transform.position = _positionSpawn;   
    }
}