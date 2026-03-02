using Magic;
using UnityEngine;
using UnityEngine.Pool;

public class MagicShooter : MonoBehaviour
{
    [SerializeField]
    public MagicMissile _missilePrefab;
    [SerializeField]
    public int _initialPoolSize = 10;

    private ObjectPool<MagicMissile> _missilePool;

    public void Initialize()
    {
        _missilePool = new ObjectPool<MagicMissile>(
            createFunc: () =>
            {
                var missile = Instantiate(_missilePrefab);
                missile.OnMissileDestroyed += HandleMissileDestroy;
                return missile;
            },
            actionOnGet: (missile) =>
            {
                missile.gameObject.SetActive(true);
                //missile.SendVFXEvent("create");
            },
            actionOnRelease: (missile) =>
            {
                missile.gameObject.SetActive(false);
                //missile.SendVFXEvent("stop");
            },
            actionOnDestroy: (missile) =>
            {
                Destroy(missile.gameObject);
            },
            collectionCheck: true,
            defaultCapacity: _initialPoolSize,
            maxSize: 50
        );
    }

    public void Shoot(Vector3 direction)
    {
        var missile = _missilePool.Get();
        missile.transform.position = transform.position;
        missile.transform.rotation = Quaternion.LookRotation(direction);
        missile.Launch(direction);
    }

    private void HandleMissileDestroy(MagicMissile missile)
    {
        _missilePool.Release(missile);
    }
}