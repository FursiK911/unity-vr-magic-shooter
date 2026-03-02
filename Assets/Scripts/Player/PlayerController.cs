using Cysharp.Threading.Tasks;
using NUnit.Framework;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private MagicShooter _leftMagicShooter;
        [SerializeField]
        private MagicShooter _rightMagicShooter;

        private void Awake()
        {
            Assert.NotNull(_leftMagicShooter, "LeftMagicShooter is null");
            Assert.NotNull(_rightMagicShooter, "RightMagicShooter is null");
        }

        private void Start()
        {
            _leftMagicShooter.Initialize();
            _rightMagicShooter.Initialize();

            TestShooting().Forget();
        }

        private async UniTask TestShooting()
        {
            while (true)
            {
                _leftMagicShooter.Shoot(Vector3.forward);
                _rightMagicShooter.Shoot(Vector3.forward);
                await UniTask.WaitForSeconds(2);
            }
        }
    }
}