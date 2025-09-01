using UnityEngine;
using UnityEngine.Pool;

public class ObjectUnityPool<TPool> where TPool : Pool
{
    private ObjectPool<TPool> _pool;
    private TPool _prefab;

    public void Initialize(int defaultCount, int maxCount)
    {
        _pool = new ObjectPool<TPool>(createFunc: () => GameObject.Instantiate(_prefab),
                                    actionOnGet: obj => obj.gameObject.SetActive(true),
                                    actionOnRelease: obj => obj.gameObject.SetActive(false),
                                    actionOnDestroy: obj => GameObject.Destroy(obj),
                                    collectionCheck: true,
                                    defaultCapacity: defaultCount,
                                    maxSize: maxCount);
    }

}
