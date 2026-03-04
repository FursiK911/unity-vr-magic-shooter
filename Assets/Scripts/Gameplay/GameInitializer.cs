using Player;
using UnityEngine;

namespace Gameplay
{
    public class GameInitializer : MonoBehaviour
    {
        [SerializeField]
        private PlayerController _playerController;

        public void Awake()
        {
            _playerController.Initialize();
        }
    }
}