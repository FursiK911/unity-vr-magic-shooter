using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.VFX;

namespace Magic
{
    public class MagicMissile : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 10f;
        [SerializeField]
        private float _lifetime = 5f;
        [SerializeField]
        private VisualEffect _vfx;

        private Vector3 _direction;
        private float _timer;
        private bool _isActive;

        public event Action<MagicMissile> OnMissileDestroyed;

        private void Update()
        {
            if (!_isActive) return;

            transform.position += _direction * _speed * Time.deltaTime;
            _timer += Time.deltaTime;

            if (_timer >= _lifetime)
            {
                Explode().Forget();
            }
        }

        public void Launch(Vector3 direction)
        {
            _timer = 0f;
            _isActive = true;
            _vfx.SendEvent("create");
            _direction = direction.normalized;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!_isActive) return;
            
            Explode().Forget();
        }

        private async UniTask Explode()
        {
            _isActive = false;

            _vfx.SendEvent("hit");
            
            await UniTask.WaitForSeconds(1);
            OnMissileDestroyed?.Invoke(this);
        }
    }
}